using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCoroutine : MonoBehaviour {
    // Start is called before the first frame update
    int timer_i=0;
    bool start_Timer=true;
    void Start() {
        
    }

    IEnumerator timer(){
        yield return new WaitForSeconds(1);
        timer_i++;
        start_Timer=true;
    }

    // Update is called once per frame
    void Update() {
        if(start_Timer){
            StartCoroutine("timer");
            start_Timer=false;
            Debug.Log(timer_i);
        }
    }
}
