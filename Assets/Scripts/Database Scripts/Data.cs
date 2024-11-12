using System;
using UnityEngine;

public class Data : ScriptableObject
{
    [Header("Data Stats")]
    private string _id;

    [SerializeField] private string _name;
    [SerializeField] private Sprite _sprite;

    public string DataID => _id;
    public string DataName => _name;
    public Sprite DataSprite => _sprite;

    protected virtual void Awake()
    {
        _id = Guid.NewGuid().ToString();
    }
}
