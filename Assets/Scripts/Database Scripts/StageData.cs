using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Data/Stage Data")]
public class StageData : Data
{
    [Header("Stage Options")]

    [SerializeField] private List<TargetGroup> _targets;

    public TargetGroup GetTarget(GameDifficultyType gameDifficulty)
    {
        int totalWeight = 0;
        _targets.ForEach(x => totalWeight += x.GetChance(gameDifficulty));

        TargetGroup[] targets = _targets.OrderBy(x => x.GetChance(gameDifficulty)).ToArray();

        int randomWeight = Random.Range(0, totalWeight);

        for (int i = 0; i < targets.Length; i++)
        {
            if (randomWeight <= targets[i].GetChance(gameDifficulty))
            {
                return targets[i];
            }
            else
            {
                totalWeight -= targets[i].GetChance(gameDifficulty);
            }
        }

        return null;
    }

}

[Serializable]
public class TargetGroup
{
    [SerializeField]
    private string _groupName;

    [SerializeField] private Data[] _targets;


    [SerializeField] private DifficultWeight[] weights;

    public string Name => _groupName;

    public int GetChance(GameDifficultyType difficulty)
    {
        foreach (DifficultWeight difficultWeight in weights)
        {
            if (difficulty == difficultWeight.Difficulty)
            {
                return difficultWeight.Weight;
            }
        }

        return default;
    }

}

[Serializable]
public struct DifficultWeight
{
    [SerializeField]
    private GameDifficultyType _difficulty;

    [SerializeField]
    [Range(0, 100)]
    private int _weight;

    public GameDifficultyType Difficulty => _difficulty;
    public int Weight => _weight;
}
