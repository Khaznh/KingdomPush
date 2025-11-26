using UnityEngine;

public class SolideTowerSpawn : State
{
    public SolideTowerSpawn(FSM fsm, Entity entity) : base(fsm, entity)
    {
    }

    public override void Enter()
    {
        base.Enter();

        SpawnSolide();

        //fsm.ChangeState();
    }

    private void SpawnSolide()
    {
        for (int i = ((SolideTowerEntity)entity).solides.Count; i <= 3 ; i++)
        {
            PoolingObject.Instance.GetGameObjectToSpawn(((SolideTowerEntity)entity).solidePrefaps);
        }
    }
}
