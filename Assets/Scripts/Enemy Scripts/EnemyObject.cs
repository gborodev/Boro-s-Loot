using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private EnemySO data;

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public void EnemyInitialize(EnemySO data, int level)
    {
        this.data = data;

        MaxHealth = (int)data.GetStatValue(EnemyStatType.Health, 1f);
        CurrentHealth = (int)data.GetStatValue(EnemyStatType.Health, 1f);
    }
}