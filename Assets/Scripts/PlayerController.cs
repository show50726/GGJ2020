using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isClimb = false;
    public Rigidbody2D player1;
    public Rigidbody2D player2;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    enum MoveParameter
    {
        RUN,
        CLIMB,
        JUMP
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
        if (isClimb && Input.GetKey((KeyCode)Player1Move.CLIMB))
        {
            player1.AddForce(Vector2.up * GetMoveParameter(MoveParameter.CLIMB), ForceMode2D.Force);
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                player1.AddForce(Vector2.left * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Force);
            }
            else if (Input.GetKey((KeyCode)Player1Move.RIGHT))
            {
                player1.AddForce(Vector2.right * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Force);
            }

            if (Input.GetKey((KeyCode)Player1Move.JUMP))
            {
                if (player1.velocity.y < 0)
                {
                    player1.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
                }
                //else if (player1.velocity.y > 0 && !Input.GetButton("Jump"))
                else if (player1.velocity.y > 0)
                {
                    player1.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                }
            }
        }
    }

    float GetMoveParameter(MoveParameter move)
    {
        switch (move)
        {
            case MoveParameter.RUN:
                return 10;
            case MoveParameter.CLIMB:
                return 10;
            case MoveParameter.JUMP:
                return 50;
        }

        // unhandled
        return 0;
    }
}
