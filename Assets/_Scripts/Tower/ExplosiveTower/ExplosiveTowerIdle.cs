using UnityEngine;

public class ExplosiveTowerIdle : State
{
    public ExplosiveTowerIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((ExplosiveTowerEntity)entity).enemyInRange.Count != 0)
        {
            fsm.ChangeState(((ExplosiveTowerEntity)entity).attack);
        }
    }
}
