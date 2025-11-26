using UnityEngine;

public class MageTowerIdle : State
{
    public MageTowerIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((MageTowerEntity)entity).enemyInRange.Count != 0)
        {
            fsm.ChangeState(((MageTowerEntity)entity).attack);
        }
    }
}
