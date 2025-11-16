using UnityEngine;

public class TowerIdle : State
{
    public TowerIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();

        ((TowerEntity)entity).pedestalAnimator.Play("Idle");
        ((TowerEntity)entity).unitAnimator.Play("Idle");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((TowerEntity)entity).enemyInRange.Count != 0)
        {
            fsm.ChangeState(((TowerEntity)entity).towerAttack);
        }
    }
}
