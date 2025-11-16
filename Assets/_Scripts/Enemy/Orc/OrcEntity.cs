using UnityEngine;

public class OrcEntity : EnemyEntity
{
    public OrcFollowState orcFollowState;
    public OrcDieState orcDieState;

    protected override void Awake()
    {
        base.Awake();

        orcFollowState = new OrcFollowState(fsm, this);
        orcDieState = new OrcDieState(fsm, this);

        fsm.Init(orcFollowState);
    }

    public void OnReset()
    {
        fsm.ChangeState(orcFollowState);
    }

    public override void ResetEnemy()
    {
        base.ResetEnemy();

        fsm.ChangeState(orcFollowState);
    }
}
