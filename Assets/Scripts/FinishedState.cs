using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedState : IState
{
    public IState nextState;
    public GameObject WinText;
    public Text Winner;
    private MainTree tree;

    private bool winner = false;  // false => player1, player2 otherwise

    public FinishedState(StateController controller) : base(controller)
    {
        state = GameManager.State.Finished;
        m_controller = controller;
    }

    public override void OnStateEnter() { 
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        WinText = tree.WinText;
        WinText.SetActive(true);
        Winner = GameObject.Find("PlayerName").GetComponent<Text>();
        if(tree.curHP <= 0){
            winner = true;
            Winner.text = "Player2";
        }
        else{
            Winner.text = "Player1";
        }

    }
    public override void StateUpdate() {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    public override void OnStateExit() { }
}
