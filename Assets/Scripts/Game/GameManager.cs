using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private RoomSO testRoom;

    public int GameLevel { get; private set; }

    private void Start()
    {
        GameLevel = 2;

        GameEvents.OnRoomStart?.Invoke(testRoom);
    }
}
