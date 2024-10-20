using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SlotController : MonoBehaviour
{
    [SerializeField] private Transform gamePanel;
    [SerializeField] private EnemySlotContent slotContentPrefab;
    [SerializeField][Range(1, 20)] private float slotAnimTime = 1f;

    private const float frontYPosition = -100f;
    private const float starterYPosition = 300f;
    private const float slotsSpacing = 200f;

    private const int minStageSlotCount = 1;
    private const int maxStageSlotCount = 3;

    private Queue<EnemySlotContent> stages = new Queue<EnemySlotContent>();

    private void OnEnable()
    {
        GameEvents.OnRoomStart += RoomStarted;
        GameEvents.SlotEvents.OnCompleteStage += StageRemove;
    }

    private void RoomStarted(RoomSO room)
    {
        RoomEnemy[] roomEnemies = room.RoomEnemies;

        int level = GameManager.instance.GameLevel;

        if (level <= 0) return; //Level is cannot be below 0

        int minEnemyCount = Mathf.FloorToInt(level * Mathf.Pow(1.25f, 2));
        int maxEnemyCount = Mathf.CeilToInt(level * Mathf.Pow(1.6f, 2));

        int randomEnemyCount = Random.Range(minEnemyCount, maxEnemyCount);

        List<EnemySO> enemyList = new List<EnemySO>();

        for (int i = 0; i < randomEnemyCount; i++)
        {
            int randomEnemy = Random.Range(0, roomEnemies.Length);
            bool isReach = roomEnemies[randomEnemy].IsReached(level);

            while (!isReach)
            {
                randomEnemy = Random.Range(0, roomEnemies.Length);
                isReach = roomEnemies[randomEnemy].IsReached(level);
            }

            enemyList.Add(roomEnemies[randomEnemy].GetEnemy());
        }

        StartCoroutine(StageInitialize(enemyList));

    }

    //StageInitialize oda y�klendi�inde odan�n contentlerini d�zenleyen fonksiyon
    private IEnumerator StageInitialize(List<EnemySO> enemies)
    {
        //D��man say�s� s�f�rdan b�y�k ise her bir contentte spawn olacak enemy say�s� hesaplan�r ve content spawnlan�r
        while (enemies.Count > 0)
        {
            int stageSlotCount = Random.Range(minStageSlotCount, maxStageSlotCount + 1);

            InstantiateStage(stageSlotCount, ref enemies);

            yield return new WaitForFixedUpdate();
        }

        //Slot contentler olu�tu�unda oyun ba�lar ve her birinin pozisyonunu art�k ekranda g�z�kecek �ekilde g�ncellenir.
        StartCoroutine(UpdatePositions());
    }

    private void InstantiateStage(int slotCount, ref List<EnemySO> enemies)
    {
        //Her bir content spawnland���nda odan�n ba�lang�c�nda pozisyonlar canvas�n d���na g�re ayarlan�r ve slota eklenip aras�ndaki mesafe artacak �ekilde s�ralan�r

        EnemySlotContent slotContent = Instantiate(slotContentPrefab, gamePanel);
        slotContent.Position = new Vector3(0, starterYPosition + (stages.Count * slotsSpacing), 0);
        slotContent.Scale = Vector3.zero;

        for (int i = 0; i < slotCount; i++)
        {
            if (enemies.Count == 0) break; //D��man say�s� s�f�r ise d�ng�den ��k�yoruz

            EnemySO enemy = enemies[Random.Range(0, enemies.Count)];
            slotContent.SetSlot(enemy);

            enemies.Remove(enemy);
        }

        stages.Enqueue(slotContent); //Eklenen contentleri stages s�ras�na ekliyoruz
    }

    private IEnumerator UpdatePositions()
    {
        float t = 0;

        while (t <= 1)
        {
            t += 1 / slotAnimTime * Time.deltaTime;

            for (int i = 0; i < stages.Count; i++)
            {
                int index = i;

                Vector3 position = new Vector2(0, frontYPosition + (index * slotsSpacing));
                Vector3 scale = Vector3.one * Mathf.Max(1f - (0.5f * index), 0);

                stages.ToArray()[index].SetPositionAndScale(position, scale, t);
            }
            yield return null;
        }
        yield return new WaitForEndOfFrame();

        //Pozisyon g�ncellemesi tamamland� ve �ndeki stage tetikleniyor
        EnemySlotContent currentStage = stages.Peek();

        GameEvents.SlotEvents.OnInitializeStage?.Invoke(currentStage);
    }

    private void StageRemove(EnemySlotContent content)
    {
        stages.Dequeue();

        Destroy(content.gameObject);
        UpdatePositions();
    }

}
