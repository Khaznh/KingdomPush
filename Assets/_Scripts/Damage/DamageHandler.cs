using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    [SerializeField] protected DamageType[] damageTypes;

    protected virtual void Awake()
    {
        damageTypes = GetComponents<DamageType>();
    }

    public virtual void DealDamage(int damage, DamageVar damageVar, int critChange)
    {

    }

    protected DamageType GetDamageType(DamageVar damageVar)
    {
        foreach (DamageType damageType in damageTypes)
        {
            if (damageType.damageType == damageVar) return damageType;
        }

        return null;
    }
}
