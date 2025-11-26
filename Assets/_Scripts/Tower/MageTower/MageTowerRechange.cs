using UnityEngine;

public class MageTowerRechange : State
{
    public MageTowerRechange(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (TimeInState() > ((MageTowerEntity)entity).stats.levels[((MageTowerEntity)entity).currentLevel].attackRate)
        {
            fsm.ChangeState(((MageTowerEntity)entity).idle);
        }
    }
}
