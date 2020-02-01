using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedState : IState
{
    public IState nextState;

    public FinishedState(StateController controller) : base(controller)
    {
        m_controller = controller;
    }

    public override void OnStateEnter() { 
    }
    public override void StateUpdate() {
    }
    public override void OnStateExit() { }
}
