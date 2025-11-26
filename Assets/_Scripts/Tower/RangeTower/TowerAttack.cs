using UnityEngine;

public class TowerAttack : State
{
    public TowerAttack(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();

        ((TowerEntity)entity).unitAnimator.Play("Attack");

        Attack();
        fsm.ChangeState(((TowerEntity)entity).towerRecharge);
    }

    private void Attack()
    {
        GameObject arrow = PoolingObject.Instance.GetGameObjectToSpawn(((TowerEntity)entity).projectilePrefaps);
        arrow.transform.position = ((TowerEntity)entity).unitAnimator.transform.position;

        arrow.GetComponent<ArrowPorjectile>().target = ((TowerEntity)entity).enemyInRange[0].transform;
        arrow.GetComponent<ArrowPorjectile>().critChange = ((TowerEntity)entity).stats.levels[((TowerEntity)entity).currentLevel].critChange;
        arrow.GetComponent<ArrowPorjectile>().dame = ((TowerEntity)entity).stats.levels[((TowerEntity)entity).currentLevel].damage;
        arrow.GetComponent<ArrowPorjectile>().ResetProjectile();
    }
}
