using UnityEngine;

public class ExplosiveTowerAttack : State
{
    public ExplosiveTowerAttack(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Attack();
        fsm.ChangeState(((ExplosiveTowerEntity)entity).rechange);
    }

    private void Attack()
    {
        GameObject arrow = PoolingObject.Instance.GetGameObjectToSpawn(((ExplosiveTowerEntity)entity).explosiveBullet);
        arrow.transform.position = ((ExplosiveTowerEntity)entity).transform.position;

        arrow.GetComponent<BombProjectType>().target = ((ExplosiveTowerEntity)entity).enemyInRange[0].transform;
        arrow.GetComponent<BombProjectType>().critChange = ((ExplosiveTowerEntity)entity).stats.levels[((ExplosiveTowerEntity)entity).currentLevel].critChange;
        arrow.GetComponent<BombProjectType>().dame = ((ExplosiveTowerEntity)entity).stats.levels[((ExplosiveTowerEntity)entity).currentLevel].damage;
        arrow.GetComponent<BombProjectType>().ResetProjectile();
    }
}

