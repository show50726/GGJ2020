using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsPool : MonoBehaviour
{
    public GameObject toolOffer;
    public Sprite icon;
    public Player.characterType toolType;
    public float y0;
    public float amplitude;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        y0 = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x,y0+amplitude*Mathf.Sin(speed*Time.time),transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerController>().getTool(toolOffer, toolType, icon);
        }
    }
}
