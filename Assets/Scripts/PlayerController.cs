using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isClimb = false;
    enum MoveParameter
    {
        RUN = 1,
        CLIMB = 1,
        JUMP = 1
    }
    enum Player1Move
    {
        LEFT = KeyCode.A,
        RIGHT = KeyCode.D,
        CLIMB = KeyCode.W,
        JUMP = KeyCode.Space,
        ATTACK = KeyCode.LeftControl
    }
    enum Player2Move
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }

    void KeyInput()
    {
        if (isClimb && Input.GetKey((KeyCode)Player1Move.CLIMB))
        {
            transform.Translate(Vector2.up * (int)MoveParameter.CLIMB * Time.deltaTime);
        }
        else
        {
            if (Input.GetKey((KeyCode)Player1Move.LEFT))
            {
                transform.Translate(Vector2.left * (int)MoveParameter.RUN * Time.deltaTime);
            }
            else if (Input.GetKey((KeyCode)Player1Move.RIGHT))
            {
                transform.Translate(Vector2.right * (int)MoveParameter.RUN * Time.deltaTime);
            }

            if (Input.GetKey((KeyCode)Player1Move.JUMP))
            {
                transform.Translate(Vector2.up * (int)MoveParameter.JUMP * Time.deltaTime);
            }
        }
    }
}
