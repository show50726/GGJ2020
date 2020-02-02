using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Leaf : MonoBehaviour
{
    public bool iswither = false;
    public Vector3 dampTarget;
    public Vector3 backTarget;
    private float dampingTargetValue;
    private float x, v;
    private bool isDamping = false;
    private MainTree tree;
    // Start is called before the first frame update


    void Start()
    {
        backTarget = transform.eulerAngles;
        if(Mathf.Abs(dampTarget.z-backTarget.z) > Mathf.Abs(dampTarget.z+(360f-backTarget.z))){
            backTarget.z = -360f+backTarget.z;
        }
        transform.eulerAngles = backTarget;
        dampTarget = new Vector3(backTarget.x, backTarget.y, backTarget.z - 10f);
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void wither(){
        tree.changeHP(20f);
        //GetComponent<SpriteRenderer>().color = new Color(1f, 0.7685f, 0.5058f);
        GetComponent<SpriteRenderer>().DOColor(new Color(1f, 0.7685f, 0.5058f), 0.2f);
        iswither = true;
    }

    public void recover(){
        tree.changeHP(-20f);
        //GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<SpriteRenderer>().DOColor(Color.white, 0.2f);
        iswither = false;
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(isDamping){
            damping();
        }
        if(startCount){
            _offset += Time.fixedDeltaTime;
        }
    }

    public void Addforce(){
        dampingTargetValue = dampTarget.z;
        isDamping = true;
    }

    public void Leave(){
        dampingTargetValue = backTarget.z;
        isDamping = true;
    }

    private void damping(){
        Spring(x, v, dampingTargetValue, 0.23f, (float)8.0 * Mathf.PI, Time.deltaTime);
        Quaternion cur = Quaternion.identity;
        cur.eulerAngles = new Vector3(backTarget.x, backTarget.y, x);
        transform.rotation = cur;
        if(x == dampingTargetValue){
            isDamping = false;
        }
    }
    
    float _offset = 0;
    bool startCount = false;
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Addforce();
            _offset = 0;
            startCount = true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player" && _offset >= 0.1f){
            Leave();
            startCount = false;
        }
    }

    void Spring
    (
        float x, float v, float xt, 
        float zeta, float omega, float h
    )
    {
        float f = 1.0f + 2.0f * h * zeta * omega;
        float oo = omega * omega;
        float hoo = h * oo;
        float hhoo = h * hoo;
        float detInv = 1.0f / (f + hhoo);
        float detX = f * x + h * v + hhoo * xt;
        float detV = v + hoo * (xt - x);
        x = detX * detInv;
        this.x = x;
        v = detV * detInv;
        this.v = v;
    }
}
