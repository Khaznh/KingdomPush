using UnityEngine;

public class MageTowerAttack : State
{
    public MageTowerAttack(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Attack();
        fsm.ChangeState(((MageTowerEntity)entity).rechange);
    }

    private void Attack()
    {
        GameObject arrow = PoolingObject.Instance.GetGameObjectToSpawn(((MageTowerEntity)entity).mageBullet);
        arrow.transform.position = ((MageTowerEntity)entity).transform.position;

        arrow.GetComponent<MageProjectype>().target = ((MageTowerEntity)entity).enemyInRange[0].transform;
        arrow.GetComponent<MageProjectype>().critChange = ((MageTowerEntity)entity).stats.levels[((MageTowerEntity)entity).currentLevel].critChange;
        arrow.GetComponent<MageProjectype>().dame = ((MageTowerEntity)entity).stats.levels[((MageTowerEntity)entity).currentLevel].damage;
        arrow.GetComponent<MageProjectype>().ResetProjectile();
    }
}
