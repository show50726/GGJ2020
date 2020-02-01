using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalEffect : MonoBehaviour
{
    public float lifeTime = 3f;
    private float _time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        if(_time > lifeTime){
            Destroy(gameObject);
        }
    }
}
