using UnityEngine;

public class FireDamageType : DamageType
{
    private void Awake()
    {
        damageType = DamageVar.Explosive;
    }

    //public override int ApplyDamage(int amount, float res, float enemyCritChange)
    //{
        
    //}
}
