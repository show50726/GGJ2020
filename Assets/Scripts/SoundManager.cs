using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource audiosource;

    public AudioClip music;
    public AudioClip JumpSFX;
    public AudioClip UseItem;
    public AudioClip GetItem;

    public GameObject MusicBk;
    public static bool IsHaveMusicBk = false;
    private GameObject clone;

    void Start()
    {
        if (!IsHaveMusicBk)
        {
            clone = Instantiate(MusicBk, transform.position, transform.rotation) as GameObject;
            IsHaveMusicBk = true;
            DontDestroyOnLoad(clone);
        }

        audiosource = GetComponent<AudioSource>();
        audiosource.clip = music;
        audiosource.Play();
    }

    void Update()
    {

    }
}