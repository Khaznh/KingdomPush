using UnityEngine;

public class Entity : MonoBehaviour
{
    
    public FSM fsm;
    
    protected virtual void Awake()
    {
        fsm = new FSM();
    }

    private void Update()
    {
        fsm.currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        fsm.currentState.UpdatePhysic();
    }
}
