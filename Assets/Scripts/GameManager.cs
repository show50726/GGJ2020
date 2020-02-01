using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float roundTime = 50f;
    public float timeLeft;
    private StateController m_stateController;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        m_stateController = GameObject.FindGameObjectWithTag("StateController");
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
