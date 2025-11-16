using UnityEngine;

public class State
{
    protected float timer;
    public FSM fsm;
    public Entity entity;

    public State(FSM fsm, Entity entity)
    {
        this.entity = entity;
        this.fsm = fsm;
    }

    public virtual void Enter()
    {
        timer = Time.time;
    }

    public virtual void Exit() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysic() { }

    public virtual float TimeInState()
    {
        return Time.time - timer;
    }
}
