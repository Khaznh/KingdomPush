using UnityEngine;

public abstract class DamageType : MonoBehaviour
{
    public DamageVar damageType;
    public float critmulti = 1.5f;

    public virtual int ApplyDamage(int amount, float res, float enemyCritChange) 
    {
        return (int)(amount * res);
    }
}
