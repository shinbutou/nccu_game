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
    public static int?[] P1_skillset = new int?[3];
    public static int?[] P2_skillset = new int?[3];

    //Players Avoidability
    public static int P1_avoid = 0;
    public static int P2_avoid = 0;

    //Deck Initialization
    int[][] Deck = new int[65][];

    //Scripts Inclusion
    public SoundController SoundEffect;
    public SkillLibrary Skills;

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

    void Skill(int skill_index, int player)
    {
        //Sound Effect
        if (skill_index <= 8)
        {
            SoundEffect.basic_skill();
        }
        else if (skill_index <= 16)
        {
            SoundEffect.chic_skill();
        }
        else
        {
            SoundEffect.super_skill();
        }

        //Effects
        switch (skill_index)
        {
            case 0:
                Skills.dispel(player);
                break;
            case 1:
                Skills.safeguard(player);
                break;
            case 2:
                Skills.basic_enhancer(player);
                break;
            case 3:
                Skills.chic_enhancer(player);
                break;
            case 4:
                Skills.super_enhancer(player);
                break;
            case 5:
                Skills.basic_blockade(player);
                break;
            case 6:
                Skills.chic_blockade(player);
                break;
            case 7:
                Skills.super_blockade(player);
                break;
            case 8:
                Skills.basic_surprise();
                break;
            case 9:
                Skills.chic_surprise();
                break;
            case 10:
                Skills.super_surprise();
                break;
            case 11:
                Skills.lightning();
                break;
            case 12:
                Skills.snatcher();
                break;
            case 13:
                Skills.steroid(player);
                break;
            case 14:
                Skills.toxicate(player);
                break;
            case 15:
                Skills.confusion(player);
                break;
            case 16:
                Skills.basic_speeder(player);
                break;
            case 17:
                Skills.chic_speeder(player);
                break;
            case 18:
                Skills.super_speeder(player);
                break;
            case 19:
                Skills.exchange(player);
                break;
            case 20:
                Skills.initialize(player);
                break;
        }
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
