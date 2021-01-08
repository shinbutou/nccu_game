using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //Background Music
    public AudioSource stage_0, stage_1, stage_2;

    //Background Sound Effect
    public AudioSource ticking;

    //Game Master Sound Effect
    public AudioSource positive, negative;

    //Skills Sound Effect
    public AudioSource basic, chic, super;

    void Start(){}

    void Update()
    {}

    void correct()
    {
        positive.Play();
    }

    void wrong()
    {
        negative.Play();
    }

    void basic_skill()
    {
        basic.Play();
    }

    void chic_skill()
    {
        chic.Play();
    }

    void super_skill()
    {
        super.Play();
    }
}
