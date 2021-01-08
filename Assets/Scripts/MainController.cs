using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //Game Essentials
    public static float P1_timer = 180;
    public static float P2_timer = 180;
    public static int P1_MP = 10;
    public static int P2_MP = 10;
    float round_time;
    public bool gameover;
    public int winner;

    //Players Countdown Speeds
    public static float P1_speed = 1;
    public static float P2_speed = 1;

    //Players Answering Logic Switches
    public static bool P1_logic = true;
    public static bool P2_logic = true;

    //Players Skillboxes
    int?[] P1_skillbox = new int?[3];
    int?[] P2_skillbox = new int?[3];

    //Players Avoidability
    public static int P1_avoid = 0;
    public static int P2_avoid = 0;

    void Start()
    {
        Deck_Shuffle();
    }

    void Update()
    {

    }

    void question_master()
    {

    }

    void Deck_Shuffle()
    {
        int[] Deck = new int[65];

        for (int i = 0; i < 65; i++)
        {
            if (i <= 12)
            {
                Deck
            }
            else if (i <= 25)
            {

            }
            else if (i <= 38)
            {

            }
            else if (i <= 51)
            {

            }
            else
            {

            }
        }
    }
}
