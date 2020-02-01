using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparingState : IState
{
    public IState nextState;
    private float curTime;
    private float countDown = 5f;

    public PreparingState(StateController controller) : base(controller)
    {
        m_controller = controller;
    }

    public override void OnStateEnter() { 
        curTime = 0f;
    }
    public override void StateUpdate() {
        curTime += Time.deltaTime;
        if(curTime >= countDown){
            m_controller.SetState(nextState);
        }
    }
    public override void OnStateExit() { }
}
