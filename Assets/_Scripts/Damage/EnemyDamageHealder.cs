using UnityEngine;

public class EnemyDamageHealder : DamageHandler
{
    private EnemyEntity enemyEntity;

    protected override void Awake()
    {
        base.Awake();

        enemyEntity = GetComponent<EnemyEntity>();
    }

    public override void DealDamage(int damage, DamageVar damageVar, int critChange)
    {
        base.DealDamage(damage, damageVar, critChange);

        DamageType damageType = GetDamageType(damageVar);

        int damageTaken = damageType.ApplyDamage(damage, GetRes(damageVar), critChange);
        TakeDamage(damageTaken);
    }

    private float GetRes(DamageVar damageVar)
    {
        switch (damageVar)
        {
            case DamageVar.Physics:
                return enemyEntity.stats.physicalResistance;
            case DamageVar.Magic:
                return enemyEntity.stats.magicResistance;
            case DamageVar.Explosive:
                return enemyEntity.stats.explosiveResistance;
            case DamageVar.Fire:
                return enemyEntity.stats.fireResistance;
            case DamageVar.Poison:
                return enemyEntity.stats.poisonResistance;
            default:
                return 0;
        }
    }

    private void TakeDamage(int damage)
    {
        enemyEntity.hp -= damage;
    }
}
