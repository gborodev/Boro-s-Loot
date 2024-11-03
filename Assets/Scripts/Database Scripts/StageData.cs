using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Stage Data")]
public class StageData : Data
{
    [Header("Stage Options")]
    [SerializeField]
    private TargetGroup _enemies;

    [SerializeField]
    private TargetGroup _collectibles;

}

[Serializable]
public class TargetGroup
{
    [SerializeField] private Data[] _targets;

    [Range(0.0f, 100.0f)]
    [SerializeField] private int _weight;

    public float Chance(GameDifficultyType gameDifficultyType)
    {
        return _weight * (int)gameDifficultyType;
    }
}
