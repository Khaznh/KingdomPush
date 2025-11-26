using UnityEngine;

public class OrcDieState : State
{
    public OrcDieState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        GameController.Instance.EarnGold(10);
        ((OrcEntity)entity).animator.Play("OrcDeath");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (TimeInState() >= 0.2f)
        {
            PoolingObject.Instance.ReturnPool(((OrcEntity)entity).gameObject);
            GameController.Instance.enemyDie += 1;
        }
    }
}
