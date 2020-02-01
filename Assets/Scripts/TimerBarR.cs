using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //使用Unity UI程式庫。
 
public class TimerBarR : MonoBehaviour {
    public Image TimerBarRColor;
    public float maxTime = 3f;
    float timerLeft;
    // public GameObject timesUpText;

    //Use this for initialization
    void Awake() {
        TimerBarRColor = GetComponent<Image>();
        
    }
    
    void Start(){
        // timesUpText.SetActive(false);
        timerLeft = maxTime;
        //StartCoroutine("DoSomething");
    }

    //Update is called once per frame
    void Update(){
        if(timerLeft>0){
            timerLeft -= Time.deltaTime;
            TimerBarRColor.fillAmount = timerLeft / maxTime;
        } else {
            // timesUpText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    /*IEnumerator DoSomething()
    {
        if(timerLeft>0)
        {
            //timerLeft -= Time.deltaTime;
            timerLeft -= 0.1f;
            TimerBarRColor.fillAmount -= timerLeft;
            yield return new WaitForSeconds(1);
            StartCoroutine("DoSomething");
        } 
        else 
        {
            // timesUpText.SetActive(true);
            Time.timeScale = 0;
            yield return null;
        }

        

    }*/
}

//=====================================================================
// public class TimerBar : MonoBehaviour {
//     //時間設定
//     int maxTime = 100;
//     public int currentTime = maxTime;
//     public Text time_UI;

//     //時間條
//     public RectTransform TimerBarR,TimerBarRColor,TimerBarL,TimerBarLColor,CountDown;

//     // Start is called before the first frame update
//     void Start() {
//         InvokeRepeating("timer",1 ,1);
//     }

//     // Update is called once per frame
//     void timer() {
//         maxTime -= 1;
//         time_UI.text = time_int + "";
//         if(maxTime == 0){
//             time_UI.text = "Time\nUp";
//             CancelInvoke("timer");
//         }
//     }

//     void Update() {
//         //將綠色血條同步到當前血量長度
//         TimerBar.sizeDelta = new Vector2(currenTime, TimerBar.sizeDelta.y);

//         //呈現傷害量
//         if (currentTime.sizeDelta.x > TimerBar.sizeDelta.x) {

//             //讓傷害量(紅色血條)逐漸追上當前血量
//             currentTime.sizeDelta += new Vector2(-1, 0)*Time.deltaTime*-1;
//         }
//     }
// }


//======================================================================
//     //時間條
//     public RectTransform TimerBarR,TimerBarRColor,TimerBarL,TimerBarLColor,CountDown;
    
//     bool start_Timer=true;
    
//     IEnumerator timer(){
//         yield return new WaitForSeconds(1);
//         maxTime--;
//         start_Timer=true;
//     }

//     //Update is called once per frame
//     void Update(){
//         if(start_Timer){
//             StartCoroutine("timer");
//             start_Timer=false;
//             Debug.Log(maxTime);
//         }
//     }
// }
