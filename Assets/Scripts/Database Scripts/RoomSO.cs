using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Room Data")]
public class RoomSO : DataSO
{
    [SerializeField] private RoomEnemy[] roomEnemies;

    public RoomEnemy[] RoomEnemies => roomEnemies;
}

[Serializable]
public class RoomEnemy
{
    [SerializeField] private EnemySO roomEnemy;
    [SerializeField] private int levelRequirement = 1;

    public EnemySO GetEnemy()
    {
        return roomEnemy;
    }

    public bool IsReached(int level)
    {
        return level >= levelRequirement;
    }
}
