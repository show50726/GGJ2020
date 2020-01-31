using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IState
{
    public GameManager.State state;
    protected StateController m_controller = null;

    public IState(StateController controller)
    {
        m_controller = controller;
    }

    public virtual void OnStateEnter() { }
    public virtual void StateUpdate() { }
    public virtual void OnStateExit() { }
}
