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

    //Rounds Management
    private bool P1_attempt = false;
    private bool P2_attempt = false;
    private bool round_winner = false;
    private bool magic = true;//Skill Authorization

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
        //Players Input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Skill_authorizer(0);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Skill_authorizer(1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            Skill_authorizer(4);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Skill_authorizer(2);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Skill_authorizer(3);
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Skill_authorizer(5);
        }
        else if (Input.GetKeyDown(KeyCode.Period))
        {
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
        }
        else if (Input.GetKeyDown(KeyCode.Slash))
        {
        }
    }

    public void Game(int[][] Deck)
    {
        //Finish the game once occur
        if (gameover)
        {
        }

        for (int i = 0; i < Deck.Length; i++)
        {
            if (Deck[i][0] == 0)//Skill Round
            {
                magic = false;
                Skill_round(Deck[i][2]);// For skill rounds switch control and dismiss skill casts
            }
            else//MP Round
            {
                magic = true;
                int question = Random.Range(0, 3);
            }
        }
        //TheDeck.Open();//Reshuffle if all cards are cast
    }

    private void Skill_round(int card)
    {
        //TheDeck;//Deal the card
    }

    private void Skill_authorizer(int key)
    {
        while (magic)
        {
            if (key <= 2)
            {
                Skill(key, 1);
            }
            else
            {
                Skill(key, 2);
            }
        }
    }

    private void Skill(int skill_index, int player)
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
