using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy Data", fileName = "New Enemy")]
public class EnemyData : Data
{
    [Header("Level Stats")]
    [SerializeField][Range(1, 100)] private int _appearanceLevel;

    [Header("Combat Stats")]
    [SerializeField] private int _baseHealth;
    [SerializeField] private int _baseArmor;
    [SerializeField] private int _baseDamage;

    public int LevelRequirement => _appearanceLevel;

    public int BaseHealth => _baseHealth;
    public int BaseArmor => _baseArmor;
    public int BaseDamage => _baseDamage;
}
