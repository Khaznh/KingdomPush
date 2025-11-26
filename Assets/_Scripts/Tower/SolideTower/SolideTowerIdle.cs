using UnityEngine;

public class SolideTowerIdle : State
{
    public SolideTowerIdle(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (((SolideTowerEntity)entity).solides.Count == 3)
        {
            return;
        }

        if (TimeInState() > ((SolideTowerEntity)entity).stats.spawnDelayTime)
        {

        }
    }
}
