using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Game Options")]
    [SerializeField] private GameDifficultyType _gameDifficulty;

    [SerializeField] private StageData testRoom;

    public int GameLevel { get; private set; }

    public GameDifficultyType GameDifficulty => _gameDifficulty;

    private void Start()
    {
        GameLevel = 2;

        GameEvents.OnRoomStart?.Invoke(testRoom);
    }
}
