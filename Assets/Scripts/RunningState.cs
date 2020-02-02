using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunningState : IState
{
    public IState nextState;
    private float curTime;
    private float roundTime = 50f;

    private Text CountDown;
    private Image L;
    private Image R;

    private MainTree tree;

    public RunningState(StateController controller) : base(controller)
    {
        state = GameManager.State.Running;
        m_controller = controller;
        nextState = new FinishedState(m_controller);
    }

    public override void OnStateEnter() { 
        curTime = 0f;
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        CountDown = GameObject.Find("maxTime").GetComponent<Text>();
        L = GameObject.Find("TimerBarLColor").GetComponent<Image>();
        R = GameObject.Find("TimerBarRColor").GetComponent<Image>();
    }
    public override void StateUpdate() {
        curTime += Time.deltaTime;  

        int tmp = ((int)roundTime - (int)curTime);
        CountDown.text = tmp.ToString();
        L.fillAmount = (roundTime-curTime) / roundTime;
        R.fillAmount = (roundTime-curTime) / roundTime;
        if(curTime >= roundTime || tree.isDead){
            m_controller.SetState(nextState);
        }
        if(curTime >= roundTime){
            CountDown.fontSize = 45;
            CountDown.GetComponent<Text>().color = Color.red;
            CountDown.text = "Time's\nUp";
        }
    }
    public override void OnStateExit() { }
}
