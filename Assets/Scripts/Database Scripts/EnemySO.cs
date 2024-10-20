using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data")]
public class EnemySO : DataSO
{
    [Header("Enemy Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private EnemyStat[] stats;

    public float GetStatValue(EnemyStatType statType, float multiplier)
    {
        return stats[(int)statType].GetValue(multiplier);
    }

    public override DataSO GetInstance()
    {
        stats = new EnemyStat[]
        {
            new EnemyStat(EnemyStatType.Health, _health),
            new EnemyStat(EnemyStatType.Damage, _damage)
        };

        return Instantiate(base.GetInstance());
    }
}

public enum EnemyStatType { Health, Damage }

public struct EnemyStat
{
    private EnemyStatType statType;
    private float baseValue;

    public EnemyStat(EnemyStatType statType, float baseValue)
    {
        this.statType = statType;
        this.baseValue = baseValue;
    }

    public float GetValue(float multiplier)
    {
        return baseValue * multiplier;
    }
}
