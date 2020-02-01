using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreparingState : IState
{
    public IState nextState;
    private float curTime;
    private float countDown = 3f;
    private Text countDownText;

    public PreparingState(StateController controller) : base(controller)
    {
        m_controller = controller;
        nextState = new RunningState(m_controller);
    }

    public override void OnStateEnter() { 
        state = GameManager.State.Preparing;
        curTime = 0f;
        countDownText = GameObject.Find("CountDown").GetComponent<Text>();
        countDownText.text = "3";
        Debug.Log("Preparing State!");
    }
    public override void StateUpdate() {
        curTime += Time.deltaTime;
        if(curTime>=2){
            countDownText.text = "1";
        }
        else if(curTime >= 1){
            countDownText.text = "2";
        }
        if(curTime >= countDown){
            m_controller.SetState(nextState);
        }
    }
    public override void OnStateExit() { 
        countDownText.text = "Go!";
        Debug.Log("Time's Up! Go to running state");
    }
}
