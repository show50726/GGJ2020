using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public toolType type;
    public float Value;

    public float freq = 1f;
    public float lifeTime = 5f;

    [SerializeField]
    private ParticleSystem particleSystem;
    public MainTree tree;

    public float y0;
    public float amplitude;
    public float speed = 1f;

    private float _time = 0f;
    private float _total;

    float baseY = -4.3f;
    float total = 7.6f;
    void Awake()
    {
        tree = GameObject.FindGameObjectWithTag("Tree").GetComponent<MainTree>();
        _time = 0f;
    }

    void Start() {
        y0 = transform.localScale.y;
        float tmp = transform.position.y - baseY;
        tmp /= total;
        tmp = 1 - tmp;
        if(tmp <= 0.45f) tmp = 0.45f;
        transform.localScale = new Vector3(tmp, tmp, tmp);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Value < 0 || freq == 0) return;

        _time += Time.deltaTime;
        _total += Time.deltaTime;

        if(type == toolType.Fire){
            float t = y0+amplitude*Mathf.Sin(speed*Time.time);
            transform.localScale = new Vector3(t, t, t);
        }

        if(_time >= freq){
            _time -= freq;
            tree.changeHP(Value);
            if(particleSystem != null){
                particleSystem.Play();
            }
        }
        if(_total >= lifeTime){
            Destroy(gameObject);
        }
    }

    public enum toolType{
        Posion, 
        Fire,
        Pesticide
    }

}
