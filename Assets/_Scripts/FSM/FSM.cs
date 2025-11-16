using UnityEngine;

public class FSM
{
    public State currentState;

    public FSM()
    {

    }

    public void ChangeState(State state)
    {
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void Init(State startState)
    {
        currentState = startState;
        startState.Enter();
    }
}
