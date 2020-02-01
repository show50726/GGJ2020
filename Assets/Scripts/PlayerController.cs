using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isClimbing = false;
    public bool isJumping = false;
    private Rigidbody2D player;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public KeyCode keyLeft;
    public KeyCode keyRight;
    public KeyCode keyClimb;
    public KeyCode keyJump;
    public KeyCode keyAttack;

    enum MoveParameter
    {
        RUN,
        CLIMB,
        JUMP
    }
    float GetMoveParameter(MoveParameter move)
    {
        switch (move)
        {
            case MoveParameter.RUN:
                return 0.6f;
            case MoveParameter.CLIMB:
                return 30;
            case MoveParameter.JUMP:
                return 30;
        }

        // unhandled
        return 0;
    }
    void AssignKey()
    {
        switch (player.name)
        {
            case "Player1":
                keyLeft = KeyCode.S;
                keyRight = KeyCode.D;
                keyClimb = KeyCode.UpArrow;
                keyJump = KeyCode.Space;
                keyAttack = KeyCode.LeftControl;
                break;
            case "Player2":
                keyLeft = KeyCode.Keypad4;
                keyRight = KeyCode.Keypad6;
                keyClimb = KeyCode.Keypad8;
                keyJump = KeyCode.Keypad0;
                keyAttack = KeyCode.KeypadEnter;
                break;
            default:
                keyLeft = KeyCode.S;
                keyRight = KeyCode.D;
                keyClimb = KeyCode.UpArrow;
                keyJump = KeyCode.Space;
                keyAttack = KeyCode.LeftControl;
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        AssignKey();
    }
    // Update is called once per frame
    void Update()
    {
        if (isClimbing && Input.GetKey(keyClimb))
        {
            player.AddForce(Vector2.up * GetMoveParameter(MoveParameter.CLIMB), ForceMode2D.Force);
        }
        else
        {
            if (Input.GetKey(keyLeft) && !isJumping)
            {
                if(player.velocity.x <= 6f)
                    player.AddForce(Vector2.left * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Impulse);
            }
            else if (Input.GetKey(keyRight) && !isJumping)
            {
                if(player.velocity.x <= 6f)
                    player.AddForce(Vector2.right * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Impulse);
            }
            else{
                //player.velocity = new Vector2(0 ,player.velocity.y);
            }

            if (Input.GetKeyDown(keyJump) && !isJumping)
            {
                player.velocity = Vector2.up * 8f;
            }

            if (Input.GetKeyUp(keyJump))
            {
                isJumping = true;
            }

            RaycastHit2D hit = Physics2D.Raycast(player.transform.position - Vector3.up * 0.8f, -Vector2.up, 0.1f);
            if (hit.collider != null && isJumping)
            {
                isJumping = false;
            }

            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (player.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }

        }
    }
}
