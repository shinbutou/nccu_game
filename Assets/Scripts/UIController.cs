using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //Answer Results
    public GameObject P1_correct;
    public GameObject P2_correct;
    public GameObject P1_wrong;
    public GameObject P2_wrong;

    //Player Message 
    public GameObject P1_timebar;
    public GameObject P2_timebar;


    void Start()
    {

    }

    void Update()
    {

    }

    /*
    public void timer_conversion(Text m_ClockText, float m_Timer)
    {
        int m_Minute = 0;
        int m_Second = 0;
        m_Second = (int)m_Timer;

        if (m_Second > 59.0f)
        {
            m_Minute = (m_Second / 60);
            m_Second = (int)(m_Timer - (m_Minute * 60));
        }

        m_Minute = (int)(m_Timer / 60);
        m_ClockText.text = string.Format("{0:d2}:{1:d2}", m_Minute, m_Second);
    }
    */
}
