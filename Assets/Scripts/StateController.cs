using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController
{
    private IState state;

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
