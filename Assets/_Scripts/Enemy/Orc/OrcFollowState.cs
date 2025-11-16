using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class OrcFollowState : State
{
    private int index;
    private float distance = 0.3f;

    public OrcFollowState(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ((OrcEntity)entity).animator.Play("OrcWalking");
        index = 0;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysic()
    {
        base.UpdatePhysic();

        if (((OrcEntity)entity).hp <= 0)
        {
            fsm.ChangeState(((OrcEntity)entity).orcDieState);
            return;
        }

        Vector3 current = ((OrcEntity)entity).transform.position;
        Vector3 target = ((OrcEntity)entity).enemyPath.transformToMove[index];

        Vector2 dir = (target - current).normalized;

        if (current.x > target.x)
        {
            ((OrcEntity)entity).sprite.flipX = true;
        }
        else
        {
            ((OrcEntity)entity).sprite.flipX = false;
        }

        ((OrcEntity)entity).rid.MovePosition(((OrcEntity)entity).rid.position + dir * ((OrcEntity)entity).stats.moveSpeed * Time.fixedDeltaTime);

        if (Vector2.Distance(((OrcEntity)entity).transform.position, ((OrcEntity)entity).enemyPath.transformToMove[index]) < distance)
        {
            index++;
        }
    }
}
