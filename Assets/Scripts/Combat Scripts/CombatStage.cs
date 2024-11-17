using System.Collections.Generic;
using UnityEngine;

public class CombatStage : MonoBehaviour
{
    [SerializeField] private EnemySlot[] _slots;

    private List<EnemySlot> _activeSlots;


    private RectTransform rect;
    public Vector3 LastPosition { get; set; } = Vector3.zero;
    public Vector3 LastScale { get; set; } = Vector3.zero;

    public Vector3 Position
    {
        get => rect.anchoredPosition;

        set
        {
            rect.anchoredPosition = value;
        }
    }
    public Vector3 Scale
    {
        get => rect.localScale;

        set
        {
            rect.localScale = value;
        }
    }
    public Color VisibilityMask
    {
        set
        {
            foreach (EnemySlot slot in _slots)
            {
                slot.SlotColor = value;
            }
        }
    }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();

        Scale = Vector3.zero;
        Position = Vector3.zero;
    }

    public void InitializeSlots(List<EnemyData> enemyDatas)
    {
        _activeSlots = new List<EnemySlot>();

        for (int i = 0; i < _slots.Length; i++)
        {
            int index = i;

            if (index > enemyDatas.Count - 1)
            {
                _slots[index].EnemyData = null;
            }
            else
            {
                _slots[index].EnemyData = enemyDatas[index];

                _activeSlots.Add(_slots[index]);
            }
        }
    }

    public List<EnemySlot> GetSlots()
    {
        return _activeSlots;
    }

    public bool IsCleared()
    {
        int count = _activeSlots.Count;

        foreach (EnemySlot slot in _activeSlots)
        {
            //Mevcut aþamanýn kalan düþman kontrolü
        }

        return count <= 0;
    }

}
