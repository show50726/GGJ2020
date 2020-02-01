using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //使用Unity UI程式庫。

public class Timer : MonoBehaviour {
    int time_int=3;
    public Text time_UI;
    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("timer",1 ,1);
    }

    // Update is called once per frame
    void timer() {
        time_int -= 1;
        time_UI.text = time_int + "";
        if(time_int == 0){
            time_UI.fontSize = 36;
            time_UI.GetComponent<Text>().color = Color.red;
            time_UI.text = "Time's\nUp";
            CancelInvoke("timer");
        }
    }
}
