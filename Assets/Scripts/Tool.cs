using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public float Value;

    public float freq = 1f;
    public float lifeTime = 5f;

    [SerializeField]
    private ParticleSystem particleSystem;
    public MainTree tree;

    private float _time = 0f;
    private float _total;

    void Awake()
    {
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        _time = 0f;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Value < 0) return;

        _time += Time.deltaTime;
        _total += Time.deltaTime;

        if(_time >= freq){
            _time -= freq;
            tree.changeHP(Value);
            particleSystem.Play();
        }
        if(_total >= lifeTime){
            Destroy(gameObject);
        }
    }



}
