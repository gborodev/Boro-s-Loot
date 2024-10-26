using System.Collections.Generic;
using UnityEngine;

public class EnemySlotContent : MonoBehaviour
{
    private List<EnemySO> enemies = new List<EnemySO>();

    private RectTransform myRect;
    private EnemySlot[] enemySlots;

    public Vector3 Position
    {
        get { return myRect.anchoredPosition; }
        set { myRect.anchoredPosition = value; }
    }

    public Vector3 Scale
    {
        get { return myRect.localScale; }
        set { myRect.localScale = value; }
    }

    private void Awake()
    {
        myRect = GetComponent<RectTransform>();
        enemySlots = GetComponentsInChildren<EnemySlot>();

        foreach (EnemySlot slot in enemySlots)
        {
            slot.gameObject.SetActive(false);
        }
    }

    public void SetPositionAndScale(Vector3 position, Vector3 scale, float t)
    {
        myRect.anchoredPosition = Vector3.Lerp(Position, position, t);
        myRect.localScale = Vector3.Lerp(Scale, scale, t);
    }

    public void SetSlot(EnemySO enemy)
    {
        enemies.Add(enemy);

        enemySlots[enemies.Count - 1].gameObject.name = enemy.Name;
        enemySlots[enemies.Count - 1].gameObject.SetActive(true);

        enemySlots[enemies.Count - 1].OnPressSlot += RemoveSlot;

    }

    public void RemoveSlot(EnemySlot slot)
    {
        slot.gameObject.SetActive(false);

        enemies.Remove(slot.Enemy);

        if (enemies.Count == 0)
        {
            Destroy(gameObject);

            GameEvents.SlotEvents.OnCompleteStage?.Invoke(this);
        }
    }
}
