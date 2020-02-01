using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    public IState state;
    

    void Start() {
        SetState(new PreparingState(this));
    }
    public void SetState(IState nextState)
    {
        if(state != null)
        {
            state.OnStateExit();
        }

        state = nextState;
        nextState.OnStateEnter();
    }


    public void StateUpdate()
    {
        if(state != null)
        {
            state.StateUpdate();
        }
    }
}
