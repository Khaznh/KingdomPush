using UnityEngine;

public class TowerRecharge : State
{
    public TowerRecharge(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (TimeInState() > ((TowerEntity)entity).stats.attackRate)
        {
            fsm.ChangeState(((TowerEntity)entity).towerIdle);
        }
    }
}
