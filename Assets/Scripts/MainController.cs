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

    //Scripts Inclusion
    public CardController TheDeck;
    public SoundController Sounds;
    public SkillLibrary Skills;

    void Start()
    {
        TheDeck = GameObject.FindWithTag("GameController").GetComponent<CardController>();
        Sounds = GameObject.FindWithTag("GameController").GetComponent<SoundController>();
        Skills = GameObject.FindWithTag("GameController").GetComponent<SkillLibrary>();
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

        if (Input.GetKeyDown(KeyCode.G))
        {
            Sounds.Basic_skill();
        }

        //Background Music
        /*
        int timer = Mathf.Max((int)P1_timer, (int)P2_timer);
        if (timer >= 120)
        {
            Sounds.start_stage();
        }
        else if (timer >= 40)
        {
            Sounds.advanced_stage();
        }
        else
        {
            Sounds.final_stage();
        }
        */
    }

    public void Game(int[][] Deck)
    {
        for (int i = 0; i < Deck.Length; i++)
        {
            if (Deck[i][0] == 0)//Skill Round
            {
            }
            else//MP Round
            {
            }
        }
    }

    void Skill(int skill_index, int player)
    {
        //Sound Effect
        if (skill_index <= 8)
        {
            Sounds.Basic_skill();
        }
        else if (skill_index <= 16)
        {
            Sounds.Chic_skill();
        }
        else
        {
            Sounds.Super_skill();
        }

        //Effects
        switch (skill_index)
        {
            case 0:
                Skills.Dispel(player);
                break;
            case 1:
                Skills.Safeguard(player);
                break;
            case 2:
                Skills.Basic_enhancer(player);
                break;
            case 3:
                Skills.Chic_enhancer(player);
                break;
            case 4:
                Skills.Super_enhancer(player);
                break;
            case 5:
                Skills.Basic_blockade(player);
                break;
            case 6:
                Skills.Chic_blockade(player);
                break;
            case 7:
                Skills.Super_blockade(player);
                break;
            case 8:
                Skills.Basic_surprise();
                break;
            case 9:
                Skills.Chic_surprise();
                break;
            case 10:
                Skills.Super_surprise();
                break;
            case 11:
                Skills.Lightning();
                break;
            case 12:
                Skills.Snatcher();
                break;
            case 13:
                Skills.Steroid(player);
                break;
            case 14:
                Skills.Toxicate(player);
                break;
            case 15:
                Skills.Confusion(player);
                break;
            case 16:
                Skills.Basic_speeder(player);
                break;
            case 17:
                Skills.Chic_speeder(player);
                break;
            case 18:
                Skills.Super_speeder(player);
                break;
            case 19:
                Skills.Exchange(player);
                break;
            case 20:
                Skills.Initialize(player);
                break;
        }
    }
}
