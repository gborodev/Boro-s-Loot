using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    [SerializeField] private EnemyData data;

    public EnemyData EnemyData { get { return data; } }

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int Damage { get; private set; }

    public void EnemyInitialize(EnemyData data, int level)
    {
        this.data = data;

        MaxHealth = data.BaseHealth;
        CurrentHealth = data.BaseHealth;

        Damage = data.BaseDamage;
    }
}