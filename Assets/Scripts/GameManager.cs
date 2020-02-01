using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private StateController m_stateController;

    private void Awake()
    {
    }


    // Start is called before the first frame update
    void Start()
    {
        m_stateController = GetComponent<StateController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_stateController != null){
            m_stateController.StateUpdate();
        }
    }

    public enum State
    {
        Preparing,
        Running,
        Finished
    }
}
