using UnityEngine;

public class MagicDamageType : DamageType
{
    private void Awake()
    {
        damageType = DamageVar.Magic;
    }

    public override int ApplyDamage(int amount, float res, float enemyCritChange)
    {
        int critChangeRandom = Random.Range(0, 101);

        if (enemyCritChange > critChangeRandom)
        {
            return (int)(amount * critmulti * res);
        }
        else
        {
            return (int)(amount * res);
        }
    }
}
