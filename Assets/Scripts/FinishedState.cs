using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishedState : IState
{
    public IState nextState;
    public GameObject WinText;
    public GameObject player1Win;
    public GameObject player2Win;
    private MainTree tree;

    private bool winner = false;  // false => player1, player2 otherwise

    public FinishedState(StateController controller) : base(controller)
    {
        state = GameManager.State.Finished;
        m_controller = controller;
    }

    public override void OnStateEnter() { 
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        if(tree.curHP <= 0){
            winner = true;
            player1Win.SetActive(false);
            player2Win.SetActive(true);
        }
        else{
            player1Win.SetActive(true);
            player2Win.SetActive(false);
        }

        WinText.SetActive(true);
    }
    public override void StateUpdate() {
        if(Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
    public override void OnStateExit() { }
}
