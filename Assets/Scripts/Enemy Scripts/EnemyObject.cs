using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private Enemy data;

    public Enemy EnemyData { get { return data; } }
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    public void EnemyInitialize(Enemy data, int level)
    {
        this.data = data;

        MaxHealth = (int)data.GetStatValue(EnemyStatType.Health, 1f);
        CurrentHealth = (int)data.GetStatValue(EnemyStatType.Health, 1f);
    }
}