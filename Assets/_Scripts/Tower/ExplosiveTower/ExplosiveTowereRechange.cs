using UnityEngine;

public class ExplosiveTowereRechange : State
{
    public ExplosiveTowereRechange(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (TimeInState() > ((ExplosiveTowerEntity)entity).stats.levels[((ExplosiveTowerEntity)entity).currentLevel].attackRate)
        {
            fsm.ChangeState(((ExplosiveTowerEntity)entity).idle);
        }
    }
}
