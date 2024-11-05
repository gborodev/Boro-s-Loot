using UnityEngine;

[CreateAssetMenu(menuName = "Data/Damageable/Collectible Data")]
public class Collectible : DamageableData
{
    [SerializeField]
    private int hitPoint = 3;


    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnHit(float damage)
    {
        hitPoint--;
    }

}
