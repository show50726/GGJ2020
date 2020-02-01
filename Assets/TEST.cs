using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
   public int i ;

    void Start()
    {
        i = 10;  
    }

    
    void Update()
    {
        if(i == 10)
        {
            i++;
            Debug.Log(i);            

        }
        
    }
}
