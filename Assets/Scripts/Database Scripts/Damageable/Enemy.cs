using UnityEngine;

[CreateAssetMenu(menuName = "Data/Damageable/Enemy Data")]
public class Enemy : DamageableData
{
    [Header("Enemy Stats")]
    [SerializeField] private int _health;
    [SerializeField] private int _damage;

    private EnemyStat[] _stats;

    public float GetStatValue(EnemyStatType statType, float multiplier)
    {
        return _stats[(int)statType].GetValue(multiplier);
    }

    protected override void Awake()
    {
        _stats = new EnemyStat[]
        {
            new EnemyStat(EnemyStatType.Health, _health),
            new EnemyStat(EnemyStatType.Damage, _damage)
        };

        base.Awake();
    }
}

public enum EnemyStatType { Health, Damage }

public struct EnemyStat
{
    private EnemyStatType _statType;
    private float _baseValue;

    public EnemyStat(EnemyStatType statType, float baseValue)
    {
        _statType = statType;
        _baseValue = baseValue;
    }

    public float GetValue(float multiplier)
    {
        return _baseValue * multiplier;
    }
}
