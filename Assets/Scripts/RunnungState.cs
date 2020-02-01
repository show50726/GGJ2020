using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnungState : IState
{
    public IState nextState;
    private float curTime;
    private float roundTime = 50f;

    public RunnungState(StateController controller) : base(controller)
    {
        m_controller = controller;
    }

    public override void OnStateEnter() { 
        curTime = 0f;
    }
    public override void StateUpdate() {
        curTime += Time.deltaTime;

        

        if(curTime >= roundTime){
            m_controller.SetState(nextState);
        }
    }
    public override void OnStateExit() { }
}
