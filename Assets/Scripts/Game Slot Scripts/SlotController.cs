using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    [SerializeField] private Transform gamePanel;
    [SerializeField] private EnemySlotContent slotContentPrefab;
    [SerializeField][Range(1, 20)] private float slotAnimTime = 1f;

    private float[] yLocations;
    private float[] scales;
    private List<EnemySlotContent> slots = new List<EnemySlotContent>();
    private const int max_slot_size = 3;

    private IEnumerator Start()
    {
        yLocations = new float[]{
            -100, 100, 300
        };
        scales = new float[]{
            1f, 0.5f, 0f
        };

        while (slots.Count < max_slot_size)
        {
            InstantiateNewSlotContent();

            yield return new WaitForSeconds(1f);
        }
    }

    private void InstantiateNewSlotContent()
    {
        int slotIndex = slots.Count;

        EnemySlotContent slotContent = Instantiate(slotContentPrefab, gamePanel);
        slotContent.Position = new Vector3(0, yLocations[^1], 0);
        slotContent.Scale = Vector3.zero;

        slots.Add(slotContent);

        StartCoroutine(UpdatePositions(slotContent, slotIndex));
    }

    private IEnumerator UpdatePositions(EnemySlotContent slot, int slotIndex)
    {
        float t = 0;

        Vector3 position = new Vector2(0, yLocations[slotIndex]);
        Vector3 scale = Vector3.one * scales[slotIndex];

        while (t < 1)
        {
            t += (1 / slotAnimTime) * Time.deltaTime;

            slot.SetPositionAndScale(position, scale, t);
            yield return null;
        }
    }

}
