using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    //Game Essentials
    public static float P1_timer = 240;
    public static float P2_timer = 240;
    public static int P1_MP = 20;
    public static int P2_MP = 20;
    public bool gameover = false;
    public int winner;

    //Players Countdown Speeds
    public static float P1_speed = 1;
    public static float P2_speed = 1;

    //Players Answering Logic Switches
    public static bool P1_logic = true;
    public static bool P2_logic = true;

    //Players Skillboxes
    int?[] P1_skillset = new int?[3];
    int?[] P2_skillset = new int?[3];

    //Players Avoidability
    public static int P1_avoid = 0;
    public static int P2_avoid = 0;

    //Deck Initialization
    int[][] Deck = new int[65][];

    void Start()
    {
        shuffled_deck();
    }

    void Update()
    {
        //Player Timers
        P1_timer -= P1_speed * Time.deltaTime;
        P2_timer -= P2_speed * Time.deltaTime;

        //Game Time Upper Limit
        if (P1_timer > 240) P1_timer = 240;
        if (P2_timer > 240) P2_timer = 240;

        //Game Basics
        if ((int)P1_timer == 0 && (int)P2_timer == 0)
        {
            gameover = true;
            winner = 0;
        }
        else if (P1_timer <= 0 && P2_timer > 0)
        {
            gameover = true;
            winner = 2;
        }
        else if (P2_timer <= 0 && P1_timer > 0)
        {
            gameover = true;
            winner = 1;
        }
    }

    void Game(int type, int value)
    {
        if (type == 0)
        {
            
        }
        else
        {}
    }

    void shuffled_deck()
    {
        //Construction
        for (int i = 0; i < 65; i++)
        {
            Deck[i] = new int[3];
            if (i <= 12)
            {
                Deck[i][0]= 1; //Club
                Deck[i][1] = i;
                Deck[i][2] = 0; //Blue
                Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            }
            else if (i <= 25)
            {
                Deck[i][0] = 2; //Diamond
                Deck[i][1] = i - 12;
                Deck[i][2] = 1; //Red
                //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            }
            else if (i <= 38)
            {
                Deck[i][0] = 3; //Heart
                Deck[i][1] = i - 25;
                Deck[i][2] = 0; //Red
                //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            }
            else if (i <= 51)
            {
                Deck[i][0] = 4; //Spade
                Deck[i][1] = i - 38; //Value
                Deck[i][2] = 0; //Blue
                //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            }
            else
            {
                Deck[i][0] = 0; //Joker
                Deck[i][1] = 0;
                if (i % 2 == 0)
                {
                    Deck[i][2] = 0; //Blue
                }
                else
                {
                    Deck[i][2] = 1; //Red
                }
                //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            }
        }

        //Shuffle
        // No clue why this didn't work
        int[] spare = new int[3];
        for (int i = 0; i < Deck.Length; i++)
        {
            spare[0] = Deck[i][0];
            spare[1] = Deck[i][1];
            spare[2] = Deck[i][2];
            int j = Random.Range(i, Deck.Length);
            Deck[i][0] = Deck[j][0];
            Deck[i][1] = Deck[j][1];
            Deck[i][2] = Deck[j][2];
            Deck[j][0] = spare[0];
            Deck[j][1] = spare[1];
            Deck[j][2] = spare[2];
        }
    }
}
