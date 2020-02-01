using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : MonoBehaviour
{
    public float dampTarget = -50f;
    public float backTarget = 331f;
    private float dampingTargetValue;
    private float x, v;
    private bool isDamping = false;
    // Start is called before the first frame update
    void Start()
    {
        backTarget = transform.eulerAngles.z;
        if(Mathf.Abs(dampTarget-backTarget) > Mathf.Abs(dampTarget+(360f-backTarget))){
            backTarget = -360f+backTarget;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Addforce();
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            Leave();
        }
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if(isDamping){
            damping();
        }
    }

    public void Addforce(){
        dampingTargetValue = dampTarget;
        isDamping = true;
    }

    public void Leave(){
        dampingTargetValue = backTarget;
        isDamping = true;
    }

    private void damping(){
        Spring(x, v, dampingTargetValue, 0.23f, (float)8.0 * Mathf.PI, Time.deltaTime);
        Quaternion cur = Quaternion.identity;
        cur.eulerAngles = new Vector3(0, 0, x);
        transform.rotation = cur;
        if(x == dampingTargetValue){
            isDamping = false;
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
