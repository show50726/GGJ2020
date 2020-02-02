using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public MainTree tree;
    public Player.characterType type;
    public GameObject tool;
    public GameObject icon;
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

    private StateController stateController;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        stateController = GameObject.FindGameObjectWithTag("StateController").GetComponent<StateController>();
    }
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

    public void getTool(GameObject tool, Player.characterType toolType, Sprite icon){
        if(toolType == type){
            this.tool = tool;
            this.icon.GetComponent<SpriteRenderer>().sprite = icon;
        }
    }

    void AssignKey()
    {
        switch (player.name)
        {
            case "Player1":
                keyLeft = KeyCode.A;
                keyRight = KeyCode.D;
                keyClimb = KeyCode.S;
                keyJump = KeyCode.W;
                keyAttack = KeyCode.LeftShift;
                break;
            case "Player2":
                keyLeft = KeyCode.LeftArrow;
                keyRight = KeyCode.RightArrow;
                keyClimb = KeyCode.M;
                keyJump = KeyCode.UpArrow;
                keyAttack = KeyCode.RightShift;
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
        if(stateController.state.state != GameManager.State.Running)
            return;

        if(tool != null){
            icon.SetActive(true);
        }
        else{
            icon.SetActive(false);
        }

        if (isClimbing && Input.GetKey(keyClimb))
        {
            player.AddForce(Vector2.up * GetMoveParameter(MoveParameter.CLIMB), ForceMode2D.Force);
        }
        else
        {
            if(Input.GetKeyDown(keyAttack) && tool != null){
                if(type == Player.characterType.Attack){
                    RaycastHit2D h = Physics2D.Raycast(player.transform.position, - Vector3.right * transform.localScale.x,  0.8f, 1<<LayerMask.NameToLayer("Tree"));
                    if(h.collider != null){
                        tree.changeHP(tool.GetComponent<Tool>().Value < 0 ? tool.GetComponent<Tool>().Value : 0);
                        Instantiate(tool, h.point, Quaternion.identity);
                        tool = null;
                    }
                }
                else{
                    RaycastHit2D h = Physics2D.Raycast(player.transform.position, - Vector3.right * transform.localScale.x,  0.8f, 1<<LayerMask.NameToLayer("Cancer"));
                    if(h.collider != null && h.collider.gameObject.GetComponent<Tool>().type == tool.GetComponent<Tool>().type){
                        tree.changeHP(tool.GetComponent<Tool>().Value);
                        Instantiate(tool, h.point, Quaternion.identity);
                        Destroy(h.transform.gameObject);
                        tool = null;
                    }
                }
                
            }

            if (Input.GetKey(keyLeft) && !isJumping)
            {
                transform.localScale = new Vector3(1, 1, 1);
                player.velocity = new Vector3(-4f, player.velocity.y, 0f);
                //if(player.velocity.x <= 6f)
                //    player.AddForce(Vector2.left * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Impulse);
            }
            else if (Input.GetKey(keyRight) && !isJumping)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                player.velocity = new Vector3(4f, player.velocity.y, 0f);
                //if(player.velocity.x <= 6f)
                //    player.AddForce(Vector2.right * GetMoveParameter(MoveParameter.RUN), ForceMode2D.Impulse);
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
            RaycastHit2D hit1 = Physics2D.Raycast(player.transform.position - Vector3.up * 0.8f - Vector3.right * 0.2f, -Vector2.up, 0.1f);
            RaycastHit2D hit2 = Physics2D.Raycast(player.transform.position - Vector3.up * 0.8f + Vector3.right * 0.2f, -Vector2.up, 0.1f);
            if ((hit.collider != null || hit1.collider != null || hit2.collider!=null) && isJumping)
            {
                isJumping = false;
            }

            if (player.velocity.y < 0)
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (player.velocity.y > 0 && !Input.GetKey(keyJump))
            {
                player.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }

        }
    }
}
