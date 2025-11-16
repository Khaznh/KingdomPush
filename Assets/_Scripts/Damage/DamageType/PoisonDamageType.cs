using UnityEngine;

public class PoisonDamageType : DamageType
{
    private void Awake()
    {
        damageType = DamageVar.Explosive;
    }

    //public override int ApplyDamage(int amount, float res, float enemyCritChange)
    //{

    //}
}
