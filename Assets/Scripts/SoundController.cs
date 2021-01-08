using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //Background Music
    public AudioSource start, advanced, final;

    //Background Sound Effect
    public AudioSource ticking;

    //Game Master Sound Effect
    public AudioSource positive, negative;

    //Skills Sound Effect
    public AudioSource basic, chic, super;

    //Synchronization
    private float P1_timer;
    private float P2_timer;

    //Monitor
    private float previous;
    private float current;

    void Start()
    {
        start.Play();
    }

    void Update()
    {
        //Background Music Control
        P1_timer = MainController.P1_timer;
        P2_timer = MainController.P2_timer;
        current = Mathf.Min(P1_timer, P2_timer);

        if (Mathf.Abs(current - previous) > 1)
        {
            BGM_manager(current);
        }

        if ((int)current - (int)previous == 1 && (current == 120 || current == 40))
        {
            BGM_manager(current);
        }

        previous = Mathf.Min(P1_timer, P2_timer);
        // Personally speaking, I would call this pure brilliance.
    }

    private void BGM_manager(float i)
    {
        if (i >= 120)
        {
            start.Play();
            advanced.Stop();
            final.Stop();
        }
        else if (i >= 40)
        {
            start.Stop();
            advanced.Play();
            final.Stop();
        }
        else
        {
            start.Stop();
            advanced.Stop();
            final.Play();
        }
    }

    //Sound Effects
    public void Correct()
    {
        positive.Play();
    }

    public void Wrong()
    {
        negative.Play();
    }

    public void Basic_skill()
    {
        basic.Play();
    }

    public void Chic_skill()
    {
        chic.Play();
    }

    public void Super_skill()
    {
        super.Play();
    }
}
