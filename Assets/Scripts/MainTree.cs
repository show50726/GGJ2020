using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTree : MonoBehaviour
{
    public GameObject[] Leaves;
    public GameObject[] Wounds;
    public float curHP;
    public float maxHP;

    public bool isDead = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    public void Reset(){
        curHP = maxHP;
        isDead = false;
        foreach(var wound in Wounds){
            wound.SetActive(false);
        }
    }

    public void changeHP(float delta){
        curHP -= delta;
        if(curHP < 0){
            curHP = 0;
        }
        else if(curHP > maxHP) {
            curHP = maxHP;
        }
    }

    public void damageTree(GameObject wound, float damage){
        wound.SetActive(true);
        //damage effect
        changeHP(damage);
    }

    public void healTree(GameObject wound, float healVal){
        wound.SetActive(false);
        //heal effect
        changeHP(healVal);
    }

    public void Death(){
        if(!isDead){
            isDead = true;
            //dead
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
