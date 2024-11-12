using GameEvents;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _gameLevel = 1;

    public int GameLevel => _gameLevel;

    private void Start()
    {
        StageEvents.OnStageStarted?.Invoke();
    }
}
