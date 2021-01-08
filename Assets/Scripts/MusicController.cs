using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource stage0;
    public AudioSource stage1;
    public AudioSource stage2;
    public AudioSource positive;
    public AudioSource negative;
    public AudioSource basicCast;
    public AudioSource chicCast;
    public AudioSource superCast;
    public AudioSource tikTok;
    float timer;

    void Start(){}

    void Update()
    {
        timer += Time.deltaTime;
        if ((int)timer % 180 < 60)
        {
            stage0.Play();
        }
        else if ((int)timer % 180 >= 60 && (int)timer % 180 < 120)
        {
            stage0.Stop();
            stage1.Play();
        }
        else if ((int)timer % 180 < 180 && (int)timer % 180 >= 120)
        {
            stage1.Stop();
            stage2.Play();
        }
    }

    void Positive()
    {
        positive.Play();
    }

    void Negative()
    {
        negative.Play();
    }
}