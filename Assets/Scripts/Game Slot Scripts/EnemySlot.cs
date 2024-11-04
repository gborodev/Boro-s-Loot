using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemySlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EnemyObject enemyObject;

    public event Action<EnemySlot> OnPressSlot;

    public Enemy Enemy => enemyObject.EnemyData;

    public void Set(Enemy enemyData, int level)
    {
        enemyObject.EnemyInitialize(enemyData, level);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressSlot?.Invoke(this);
    }
}
