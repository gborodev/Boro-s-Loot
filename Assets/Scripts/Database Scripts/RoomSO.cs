using UnityEngine;

[CreateAssetMenu(menuName = "Data/Room Data")]
public class RoomSO : DataSO
{
    [Header("Room Options")]
    [SerializeField] private int _levelRequirement;

    [Header("Datas")]
    [SerializeField] private EnemySO[] _enemies;

    public EnemySO[] Enemies => _enemies;
}
