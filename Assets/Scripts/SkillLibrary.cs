using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLibrary : MonoBehaviour
{
    //Initialization
    public float P1_timer;
    public float P2_timer;
    public float P1_speed;
    public float P2_speed;
    public int P1_MP;
    public int P2_MP;
    public bool P1_logic;
    public bool P2_logic;
    public int P1_avoid;
    public int P2_avoid;

    void Start(){}

    void Update()
    {
        //Synchronization
        P1_timer = MainController.P1_timer;
        P2_timer = MainController.P2_timer;
        P1_speed = MainController.P1_speed;
        P2_speed = MainController.P2_speed;
        P1_MP = MainController.P1_MP;
        P2_MP = MainController.P2_MP;
        P1_logic = MainController.P1_logic;
        P2_logic = MainController.P2_logic;
        P1_avoid = MainController.P1_avoid;
        P2_avoid = MainController.P2_avoid;
    }

    public void Dispel(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 2)
                {
                    MainController.P1_logic = true;
                    MainController.P1_speed = 1;
                    MainController.P1_MP -= 2;
                    //p1_state_1.SetActive(false);
                    //p1_state_2.SetActive(false);
                    //p1_state_3.SetActive(false);
                }
                break;

            case 2:
                if (P2_MP >= 2)
                {
                    MainController.P2_logic = true;
                    MainController.P2_speed = 1;
                    MainController.P2_MP -= 2;
                    //p1_state_1.SetActive(false);
                    //p1_state_2.SetActive(false);
                    //p1_state_3.SetActive(false);
                }
                break;
        }
    }

    public void Safeguard(int player)
    {
        int guard_random = Random.Range(0, 2);
        switch (player)
        {
            case 1:
                if (P1_MP >= 3)
                {
                    MainController.P1_MP -= 3;
                    if (guard_random == 1)
                    {
                        MainController.P1_avoid += 1;
                    }
                }
                break;
            case 2:
                if (P2_MP >= 3)
                {
                    MainController.P2_MP -= 3;
                    if (guard_random == 1)
                    {
                        MainController.P2_avoid += 1;
                    }
                }
                break;
        }
    }

    public void Basic_enhancer(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 3)
                {
                    MainController.P1_timer += 5;
                    MainController.P1_MP -= 3;
                }
                break;

            case 2:
                if (P2_MP >= 3)
                {
                    MainController.P2_timer += 5;
                    MainController.P2_MP -= 3;
                }
                break;
        }
    }

    public void Chic_enhancer(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 6)
                {
                    MainController.P1_timer += 10;
                    MainController.P1_MP -= 6;
                }
                break;

            case 2:
                if (P2_MP >= 6)
                {
                    MainController.P2_timer += 10;
                    MainController.P2_MP -= 6;
                }
                break;
        }
    }

    public void Super_enhancer(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 9)
                {
                    MainController.P1_timer += 20;
                    MainController.P1_MP -= 9;
                }
                break;

            case 2:
                if (P2_MP >= 9)
                {
                    MainController.P2_timer += 20;
                    MainController.P2_MP -= 9;
                }
                break;
        }
    }

    public void Basic_blockade(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 3)
                {
                    MainController.P2_timer -= 5;
                    MainController.P1_MP -= 3;
                }
                break;

            case 2:
                if (P2_MP >= 3)
                {
                    MainController.P1_timer += 5;
                    MainController.P2_MP -= 3;
                }
                break;
        }
    }

    public void Chic_blockade(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 6)
                {
                    MainController.P2_timer -= 10;
                    MainController.P1_MP -= 6;
                }
                break;

            case 2:
                if (P2_MP >= 6)
                {
                    MainController.P1_timer += 10;
                    MainController.P2_MP -= 6;
                }
                break;
        }
    }

    public void Super_blockade(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 9)
                {
                    MainController.P2_timer -= 20;
                    MainController.P1_MP -= 9;
                }
                break;

            case 2:
                if (P2_MP >= 9)
                {
                    MainController.P1_timer += 20;
                    MainController.P2_MP -= 9;
                }
                break;
        }
    }

    public void Basic_surprise()
    {
    }

    public void Chic_surprise()
    {
    }

    public void Super_surprise()
    {
    }

    public void Lightning()
    {
    }

    public void Snatcher()
    {
    }

    public void Steroid(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 12)
                {
                    MainController.P1_timer *= 1.5f;
                    MainController.P1_MP -= 12;
                }
                break;

            case 2:
                if (P2_MP >= 12)
                {
                    MainController.P2_timer *= 1.5f;
                    MainController.P2_MP -= 12;
                }
                break;
        }
    }

    public void Toxicate(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 12)
                {
                    MainController.P2_timer /= 1.5f;
                    MainController.P1_MP -= 12;
                }
                break;

            case 2:
                if (P2_MP >= 12)
                {
                    MainController.P1_timer /= 1.5f;
                    MainController.P2_MP -= 12;
                }
                break;
        }
    }

    public void Confusion(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 15)
                {
                    if (P2_logic == true)
                    {
                        MainController.P2_logic = false;
                    }
                    else
                    {
                        MainController.P2_logic = true;
                    }
                    MainController.P1_MP -= 15;
                    //p1_state_2.SetActive(true);
                }
                break;

            case 2:
                if (P2_MP >= 15)
                {
                    if (P1_logic == true)
                    {
                        MainController.P1_logic = false;
                    }
                    else
                    {
                        MainController.P1_logic = true;
                    }
                    MainController.P2_MP -= 15;
                    //p1_state_2.SetActive(true);
                }
                break;
        }
    }

    public void Basic_speeder(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 15)
                {
                    MainController.P2_speed *= 1.3f;
                    MainController.P1_MP -= 15;
                    //p2_state_1.SetActive(true);
                }
                break;

            case 2:
                if (P2_MP >= 15)
                {
                    MainController.P1_speed *= 1.3f;
                    MainController.P2_MP -= 15;
                    //p2_state_1.SetActive(true);
                }
                break;
        }
    }

    public void Chic_speeder(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 18)
                {
                    MainController.P2_speed *= 1.6f;
                    MainController.P1_MP -= 18;
                    //p2_state_1.SetActive(true);
                }
                break;

            case 2:
                if (P2_MP >= 18)
                {
                    MainController.P1_speed *= 1.6f;
                    MainController.P2_MP -= 18;
                    //p2_state_1.SetActive(true);
                }
                break;
        }
    }

    public void Super_speeder(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 20)
                {
                    MainController.P2_speed *= 1.9f;
                    MainController.P1_MP -= 20;
                    //p2_state_1.SetActive(true);
                }
                break;

            case 2:
                if (P2_MP >= 20)
                {
                    MainController.P1_speed *= 1.9f;
                    MainController.P2_MP -= 20;
                    //p2_state_1.SetActive(true);
                }
                break;
        }
    }

    public void Exchange(int player)
    {
        bool pass = false;
        switch (player)
        {
            case 1:
                if (P1_MP >= 20)
                {
                    MainController.P1_MP -= 20;
                    pass = true;
                }
                break;

            case 2:
                if (P2_MP >= 20)
                {
                    MainController.P2_MP -= 20;
                    pass = true;
                }
                break;
        }

        if (pass)
        {
            int tmp_int;
            float tmp_float;
            bool tmp_bool;
            int?[] tmp_skillset = new int?[3];

            tmp_int = MainController.P1_MP;
            MainController.P1_MP = MainController.P2_MP;
            MainController.P2_MP = tmp_int;

            tmp_int = MainController.P1_avoid;
            MainController.P1_avoid = MainController.P2_avoid;
            MainController.P2_avoid = tmp_int;

            tmp_float = MainController.P1_timer;
            MainController.P1_timer = MainController.P2_timer;
            MainController.P2_timer = tmp_float;

            tmp_float = MainController.P1_speed;
            MainController.P1_speed = MainController.P2_speed;
            MainController.P2_speed = tmp_float;

            tmp_bool = MainController.P1_logic;
            MainController.P1_logic = MainController.P2_logic;
            MainController.P2_logic = tmp_bool;

            tmp_skillset = MainController.P1_skillset;
            MainController.P1_skillset = MainController.P2_skillset;
            MainController.P2_skillset = tmp_skillset;
        }
    }

    public void Initialize(int player)
    {
        switch (player)
        {
            case 1:
                if (P1_MP >= 20)
                {
                    MainController.P1_timer = 240;
                    MainController.P1_MP = 20;

                    //int specskill = Random.Range(1, 10);
                    //p1_skill_1.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_1.SetActive(true);
                    //player1skill[0] = specskill;

                    //specskill = Random.Range(1, 10);
                    //p1_skill_2.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_2.SetActive(true);
                    //player1skill[1] = specskill;

                    //specskill = Random.Range(1, 10);
                    //p1_skill_3.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_3.SetActive(true);
                    //player1skill[2] = specskill;
                }
                break;

            case 2:
                if (P2_MP >= 20)
                {
                    MainController.P2_timer = 240;
                    MainController.P2_MP = 20;

                    //int specskill = Random.Range(1, 10);
                    //p1_skill_1.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_1.SetActive(true);
                    //player1skill[0] = specskill;

                    //specskill = Random.Range(1, 10);
                    //p1_skill_2.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_2.SetActive(true);
                    //player1skill[1] = specskill;

                    //specskill = Random.Range(1, 10);
                    //p1_skill_3.GetComponent<Image>().sprite = skills[specskill];
                    //p1_skill_3.SetActive(true);
                    //player1skill[2] = specskill;
                }
                break;

        }
    }
}
