﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTree : MonoBehaviour
{
    //public GameObject[] Leaves;
    //public GameObject[] Wounds;
    public float curHP;
    public float maxHP;

    public bool isDead = false;
    public GameObject WinText;
    public Image LBar;
    public Image RBar;
    
    // Start is called before the first frame update
    void Start()
    {
        initialize();
    }

    public void initialize(){
        curHP = maxHP;
        isDead = false;
        LBar.fillAmount = curHP / maxHP;
        RBar.fillAmount = curHP / maxHP;
        /*
        foreach(var wound in Wounds){
            wound.SetActive(false);
        }
        */
    }

    public void changeHP(float delta){
        curHP -= delta;
        if(curHP <= 0){
            curHP = 0;
            LBar.fillAmount = curHP / maxHP;
            RBar.fillAmount = curHP / maxHP;
            Death();
        }
        else if(curHP > maxHP) {
            curHP = maxHP;
        }
        LBar.fillAmount = curHP / maxHP;
        RBar.fillAmount = curHP / maxHP;
    }

    public void damageTree(GameObject wound, float damage){
        //wound.SetActive(true);
        //damage effect
        changeHP(damage);
    }

    public void healTree(GameObject wound, float healVal){
        //wound.SetActive(false);
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
