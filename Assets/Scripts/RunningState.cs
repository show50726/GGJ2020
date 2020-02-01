using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : IState
{
    public IState nextState;
    private float curTime;
    private float roundTime = 50f;

    public RunningState(StateController controller) : base(controller)
    {
        state = GameManager.State.Running;
        m_controller = controller;
        nextState = new FinishedState(m_controller);
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
