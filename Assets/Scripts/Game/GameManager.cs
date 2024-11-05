using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Options")]
    [SerializeField] private GameDifficultyType _gameDifficulty;

    [SerializeField] private StageData testStage;

    public GameDifficultyType GameDifficulty => _gameDifficulty;

    private IEnumerator Start()
    {
        int i = 0;

        while (i < 1000)
        {
            i++;

            Debug.Log(testStage.GetTarget(_gameDifficulty).Name);
            yield return null;
        }
    }
}
