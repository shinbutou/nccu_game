using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    int[] points = {2, 3, 3, 6, 9, 3, 6, 9, 3, 5, 5, 5, 5, 12, 12, 15, 15, 18, 20, 20, 20};
    public Image first;
    public List<int> cards = new List<int>();
    public List<Sprite> poker = new List<Sprite>();
    public GameObject timebar1;//時間條1
    public GameObject timebar2;//時間條2
    //答對答錯
    public GameObject circle1;
    public GameObject circle2;
    public GameObject cross1;
    public GameObject cross2;
    public Text p1s1, p1s2, p1s3, p2s1, p2s2, p2s3;

    public Text counter1;//時間碼表
    public Text counter2;

    public Text[] Q1;//題目，有六個
    public Text[] Q2;

    public Text s1;//技能點數顯示1
    public Text s2;//技能點數顯示2
    public Text cardnum;//卡牌點數

    int pivot;//比大小的判斷數字
    int temp;
    int randomIndex;//隨機卡牌點

    int SkillPoint1 = 10;
    int SkillPoint2 = 10;

    //倒計時速度
    float speed1 = 1;
    float speed2 = 1;
    //答題冷卻
    float QuestionCoolTime;
    //判斷時間是否過5秒
    float timenow;
    //題目index
    float randomQuestion;
    //碼表
    float timer = 0;
    //血量長度
    float x1;
    float x2;
    //總共玩家時間
    float Player1Time = 180;
    float Player2Time = 180;
    //玩家選擇的按鈕
    int P1_state;
    int P2_state;
    int num;
    //是否答題結束去下一題
    bool next = false;
    //是否在冷卻中
    bool CanControl = true;
    //邏輯顛倒
    bool logic_1_change = false;
    bool logic_2_change = false;
    //回避技能
    bool avoid_skill_1 = false;
    bool avoid_skill_2 = false;
    bool avoidable;

    List<Sprite> skills = new List<Sprite>();

    int?[] player1skill = new int?[3];
    int?[] player2skill = new int?[3];
    public GameObject p1_skill_1, p1_skill_2, p1_skill_3, p2_skill_1, p2_skill_2, p2_skill_3, showing_card;
    public GameObject p1_state_1, p1_state_2, p1_state_3, p2_state_1, p2_state_2, p2_state_3;
    public Sprite skill_1_picture, skill_2_picture, skill_3_picture, skill_4_picture, skill_5_picture,
        skill_6_picture, skill_7_picture, skill_8_picture, skill_9_picture, skill_10_picture, skill_11_picture,
        skill_12_picture, skill_13_picture, skill_14_picture, skill_15_picture, skill_16_picture, skill_17_picture,
        skill_18_picture, skill_19_picture, skill_20_picture, skill_21_picture, state_1;
    public Sprite card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13, card14,
        card15, card16, card17, card18, card19, card20, card21, card22, card23, card24, card25, card26, card27, card28, card29,
        card30, card31, card32, card33, card34, card35, card36, card37, card38, card39, card40, card41, card42, card43, card44,
        card45, card46, card47, card48, card49, card50, card51, card52, card53, card54, card55, card56, card57, card58, card59, card60;

    int stat;
    public bool haswinner;
    public int winner_player;


    public AudioSource correct;
    public AudioSource wrong;
    public AudioSource s_ele;
    public AudioSource s_adv;
    public AudioSource s_super;

    // Start is called before the first frame update
    void Start()
    {
        first.gameObject.SetActive(true);
        haswinner = false;
        winner_player = 0;

        stat = 0;

        skills.Add(skill_1_picture);
        skills.Add(skill_2_picture);
        skills.Add(skill_3_picture);
        skills.Add(skill_4_picture);
        skills.Add(skill_5_picture);
        skills.Add(skill_6_picture);
        skills.Add(skill_7_picture);
        skills.Add(skill_8_picture);
        skills.Add(skill_9_picture);
        skills.Add(skill_10_picture);
        skills.Add(skill_11_picture);
        skills.Add(skill_12_picture);
        skills.Add(skill_13_picture);
        skills.Add(skill_14_picture);
        skills.Add(skill_15_picture);
        skills.Add(skill_16_picture);
        skills.Add(skill_17_picture);
        skills.Add(skill_18_picture);
        skills.Add(skill_19_picture);
        skills.Add(skill_20_picture);
        skills.Add(skill_21_picture);
        showing_card.GetComponent<Image>().sprite = card2;
        int specskill = Random.Range(20, 21);
        //  specskill = 12;

        p1_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
        p1_skill_1.SetActive(true);
        player1skill[0] = specskill;
        specskill = Random.Range(1, 22);
        //  specskill = 13;

        p1_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
        p1_skill_2.SetActive(true);
        player1skill[1] = specskill;
        specskill = Random.Range(1, 22);
        //specskill = 12;

        p1_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
        p1_skill_3.SetActive(true);
        player1skill[2] = specskill;
        specskill = Random.Range(1, 22);
        //     specskill = 10;

        p2_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
        p2_skill_1.SetActive(true);
        player2skill[0] = specskill;
        specskill = Random.Range(1, 22);
        //   specskill = 9;

        p2_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
        p2_skill_2.SetActive(true);
        player2skill[1] = specskill;
        specskill = Random.Range(1, 22);
        // specskill = 10;

        p2_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
        p2_skill_3.SetActive(true);
        player2skill[2] = specskill;

        for (int i = 0; i < 60; i++)
        {
            cards.Add(i + 1);

        }

        //Shuffle(cards);//洗牌
        //設定初始長度
        x1 = timebar1.GetComponent<RectTransform>().localScale.x;
        x2 = timebar2.GetComponent<RectTransform>().localScale.x;

        //問題一開始先不顯示
        foreach (Text i in Q1)
        {
            i.gameObject.SetActive(false);
        }

        //foreach (Text i in Q2)
        //{
        //    i.gameObject.SetActive(false);
        //}
        //答對答錯隱藏
        circle1.SetActive(false);
        circle2.SetActive(false);
        cross1.SetActive(false);
        cross2.SetActive(false);
        p1_state_1.SetActive(false);
        p1_state_2.SetActive(false);
        p1_state_3.SetActive(false);
        p2_state_1.SetActive(false);
        p2_state_2.SetActive(false);
        p2_state_3.SetActive(false);
        poker.Add(card1);
        poker.Add(card2);
        poker.Add(card3);
        poker.Add(card4);
        poker.Add(card5);
        poker.Add(card6);
        poker.Add(card7);
        poker.Add(card8);
        poker.Add(card9);
        poker.Add(card10);
        poker.Add(card11);
        poker.Add(card12);
        poker.Add(card13);
        poker.Add(card14);
        poker.Add(card15);
        poker.Add(card16);
        poker.Add(card17);
        poker.Add(card18);
        poker.Add(card19);
        poker.Add(card20);
        poker.Add(card21);
        poker.Add(card22);
        poker.Add(card23);
        poker.Add(card24);
        poker.Add(card25);
        poker.Add(card26);
        poker.Add(card27);
        poker.Add(card28);
        poker.Add(card29);
        poker.Add(card30);
        poker.Add(card31);
        poker.Add(card32);
        poker.Add(card33);
        poker.Add(card34);
        poker.Add(card35);
        poker.Add(card36);
        poker.Add(card37);
        poker.Add(card38);
        poker.Add(card39);
        poker.Add(card40);
        poker.Add(card41);
        poker.Add(card42);
        poker.Add(card43);
        poker.Add(card44);
        poker.Add(card45);
        poker.Add(card46);
        poker.Add(card47);
        poker.Add(card48);
        poker.Add(card49);
        poker.Add(card50);
        poker.Add(card51);
        poker.Add(card52);
        poker.Add(card53);
        poker.Add(card54);
        poker.Add(card55);
        poker.Add(card56);
        poker.Add(card57);
        poker.Add(card58);
        poker.Add(card59);
        poker.Add(card60);



    }

    void Update()
    {
        //int num1 = (int)player1skill[0];
        //int num2 = (int)player1skill[1];
        //int num3 = (int)player1skill[2];
        //int num4 = (int)player2skill[0];
        //int num5 = (int)player2skill[1];
        //int num6 = (int)player2skill[2];
        //p1s1.text =string.Format ("{0:d},num",points[num1-1]);
        //p1s2.text = string.Format("{0:d},num", points[num2-1]);
        //p1s3.text = string.Format("{0:d},num", points[num3-1]);
        //p2s1.text = string.Format("{0:d},num", points[num4-1]);
        //p2s2.text = string.Format("{0:d},num", points[num5-1]);
        //p2s3.text = string.Format("{0:d},num", points[num6-1]);
        if (timer > 1.5)
        {
            first.gameObject.SetActive(false);
        }

        if ((int)Player1Time <= 0 && (int)Player2Time > 0)
        {
            haswinner = true;
            winner_player = 2;
        }
        else if ((int)Player1Time > 0 && (int)Player2Time <= 0)
        {
            haswinner = true;
            winner_player = 1;
        }
        else if ((int)Player1Time == 0 && (int)Player2Time == 0)
        {
            haswinner = true;
            winner_player = 0;
        }

        if (Player1Time > 180) Player1Time = 180;
        if (Player2Time > 180) Player2Time = 180;

        //碼表
        if (!haswinner)
            timer += Time.deltaTime;

        //如果答題冷卻結束，把圈叉隱藏
        if (timer - QuestionCoolTime > 2)
        {
            //timenow = timer;
            CanControl = true;
            // next = true;
            circle1.SetActive(false);
            circle2.SetActive(false);
            cross1.SetActive(false);
            cross2.SetActive(false);
        }
        //答題冷卻中
        else
        {
            cardnum.text = "next question";
        }

        //如果超過5秒或答題結束，換題
        if (timer - timenow > 5 || next == true)
        {

            QuestionCoolTime = timer;
            if (next == true)
            {
                CanControl = false;
                next = false;
            }
            temp = Random.Range(0, 53);// Random.Range(0, cards.Count);

            randomIndex = cards[temp];

            randomQuestion = Random.Range(0, 6);
            timenow = timer;
            if (randomQuestion == 0)//奇數偶數
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                        Q1[i].gameObject.SetActive(true);
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //        Q2[i].gameObject.SetActive(true);
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            else if (randomQuestion == 1)//偶數奇數
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                        Q1[i].gameObject.SetActive(true);
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //        Q2[i].gameObject.SetActive(true);
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            else if (randomQuestion == 2)//紅黑
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                        Q1[i].gameObject.SetActive(true);
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //        Q2[i].gameObject.SetActive(true);
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            else if (randomQuestion == 3)//黑紅
            {
                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                        Q1[i].gameObject.SetActive(true);
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //        Q2[i].gameObject.SetActive(true);
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            else if (randomQuestion == 4)//大小
            {
                num = randomIndex % 13;
                if (num == 0) num = 13;

                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                    {
                        pivot = Random.Range(2, 13);
                        Q1[4].text = string.Format(">={0:d}    <{1:d}", pivot, pivot);
                        Q1[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //    {

                //        Q2[4].text = string.Format(">={0:d}    <{1:d}", pivot, pivot);
                //        Q2[i].gameObject.SetActive(true);                       
                //    }
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            else if (randomQuestion == 5)//小大
            {
                num = randomIndex % 13;
                if (num == 0) num = 13;

                for (int i = 0; i < 6; i++)
                {
                    if (i == randomQuestion)
                    {
                        pivot = Random.Range(2, 13);
                        Q1[5].text = string.Format("<{0:d}    >={1:d}", pivot, pivot);
                        Q1[i].gameObject.SetActive(true);
                    }
                    else
                    {
                        Q1[i].gameObject.SetActive(false);
                    }
                }
                //for (int i = 0; i < 6; i++)
                //{
                //    if (i == randomQuestion)
                //    {

                //        Q2[5].text = string.Format(">={0:d}    <{1:d}", pivot, pivot);
                //        Q2[i].gameObject.SetActive(true);
                //    }
                //    else
                //    {
                //        Q2[i].gameObject.SetActive(false);
                //    }
                //}
            }
            P1_state = 0;
            P2_state = 0;

        }
        //如果沒在冷卻，可以判斷誰答對（line277~1031）
        if (CanControl)
        {
            skillchoice();
            //joker
            if (randomIndex > 52)
            {
                showing_card.GetComponent<Image>().sprite = poker[randomIndex + 1];
                stat = 1;

                if (stat == 1)
                { stat = robskill(stat); }
            }
            //normal card
            else
            {
                showing_card.GetComponent<Image>().sprite = poker[randomIndex + 1];
                //p1
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (!logic_1_change)
                        P1_state = 2;
                    else
                    {
                        P1_state = 3;
                    }
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    if (!logic_1_change)
                        P1_state = 3;
                    else
                    {
                        P1_state = 2;
                    }
                }
                if (Input.GetKeyDown(KeyCode.K))
                {
                    if (!logic_2_change)
                        P2_state = 2;
                    else
                    {
                        P2_state = 3;
                    }
                }
                if (Input.GetKeyDown(KeyCode.L))
                {
                    if (!logic_2_change)
                        P2_state = 3;
                    else
                        P2_state = 2;
                }


                //odd or even
                if (randomQuestion == 0)
                {
                    int num5 = randomIndex % 13;
                    if (num5 == 0) num5 = 13;
                    if (num5 % 2 == 0)//answer is even
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            SkillPoint1++;
                            next = true;
                            circle1.gameObject.SetActive(true);
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            SkillPoint2++;
                            next = true;
                            circle2.gameObject.SetActive(true);
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                circle1.gameObject.SetActive(true);
                                SkillPoint1++;

                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;

                                next = true;
                                correct.Play();
                            }
                        }

                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            SkillPoint1--;
                            next = true;
                            cross1.gameObject.SetActive(true);
                            wrong.Play();

                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            SkillPoint2--;
                            next = true;
                            cross2.gameObject.SetActive(true);
                            wrong.Play();

                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            next = true;
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            wrong.Play();
                        }
                    }
                    //answer is odd
                    else
                    {
                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            SkillPoint1++;
                            next = true;
                            circle1.gameObject.SetActive(true);
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            // P2 get MP
                            SkillPoint2++;
                            next = true;
                            circle2.gameObject.SetActive(true);
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                circle1.gameObject.SetActive(true);
                                SkillPoint1++;

                                next = true; correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                correct.Play();
                                next = true;
                            }
                        }
                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }

                    }
                }
                //even or odd
                else if (randomQuestion == 1)
                {
                    int num4 = randomIndex % 13;
                    if (num4 == 0) num4 = 13;
                    if (num4 % 2 == 0)//answer is even
                    {

                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            // P2 get MP
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP

                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                circle1.gameObject.SetActive(true);
                                SkillPoint1++;
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }

                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                    //answer is odd
                    else
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP

                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                SkillPoint2++;
                                circle2.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                }
                //red or black
                else if (randomQuestion == 2)
                {
                    bool color;
                    if ((randomIndex - 1) / 13 == 0 || (randomIndex - 1) / 13 == 3)
                    {
                        color = true; //black
                    }
                    else
                    {
                        color = false; // red
                    }
                    if (color)
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                circle1.gameObject.SetActive(true);
                                SkillPoint1++;
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                    else
                    {
                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                }
                //black or red
                else if (randomQuestion == 3)
                {
                    bool color;
                    if ((randomIndex - 1) / 13 == 0 || (randomIndex - 1) / 13 == 3)
                    {
                        color = true; //black
                    }
                    else
                    {
                        color = false; // red
                    }
                    if (!color)
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                circle1.gameObject.SetActive(true);
                                SkillPoint1++;
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                SkillPoint2++;
                                circle2.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                    else
                    {
                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                SkillPoint2++;
                                circle2.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                }
                //big/equal or small
                else if (randomQuestion == 4)
                {



                    print(num);
                    if (num >= pivot)
                    {
                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP

                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                    else
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                SkillPoint2++;
                                circle2.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                }
                //small or big/equal
                else
                {


                    if (num < pivot)
                    {
                        if (P1_state == 2 && P2_state != 2)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 2 && P1_state != 2)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 2 && P2_state == 2)
                        { //random get MP
                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                circle2.gameObject.SetActive(true);
                                SkillPoint2++;
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 3 && P2_state == 3)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 3 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 3 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                    else
                    {
                        if (P1_state == 3 && P2_state != 3)
                        { // P1 get MP
                            circle1.gameObject.SetActive(true);
                            SkillPoint1++;
                            next = true;
                            correct.Play();
                        }
                        if (P2_state == 3 && P1_state != 3)
                        {
                            // P2 get MP
                            circle2.gameObject.SetActive(true);
                            SkillPoint2++;
                            next = true;
                            correct.Play();
                        }
                        if (P1_state == 3 && P2_state == 3)
                        { //random get MP

                            if (Random.Range(1, 3) % 2 == 0)
                            {
                                SkillPoint1++;
                                circle1.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                            else
                            {
                                SkillPoint2++;
                                circle2.gameObject.SetActive(true);
                                next = true;
                                correct.Play();
                            }
                        }
                        if (P1_state == 2 && P2_state == 2)
                        {
                            cross1.gameObject.SetActive(true);
                            cross2.gameObject.SetActive(true);
                            next = true;
                            wrong.Play();
                        }
                        if (P1_state == 2 && P2_state == 0)
                        {
                            //p1 minus MP
                            cross1.gameObject.SetActive(true);
                            SkillPoint1--;
                            next = true;
                            wrong.Play();
                        }
                        if (P2_state == 2 && P1_state == 0)
                        {
                            //p2 minus mp
                            cross2.gameObject.SetActive(true);
                            SkillPoint2--;
                            next = true;
                            wrong.Play();
                        }
                    }
                }
            }
            //判斷答題完進冷卻
            QuestionCoolTime = timer;
            //更新技能點數
            s1.text = string.Format("{0:d}", SkillPoint1);
            s2.text = string.Format("{0:d}", SkillPoint2);
            //更新卡牌index
            cardnum.text = string.Format("{0:d}", randomIndex);

        }
        if (timer - timenow > 5)
        {
            timenow = timer;
        }
        //設定UI//

        //每秒倒數
        Player1Time -= speed1 * 1.5f * Time.deltaTime;
        Convert(counter1, Player1Time);//把float換00：00
        Player2Time -= speed2 * 1.5f * Time.deltaTime;
        Convert(counter2, Player2Time);

        //調長度
        if (timebar1.GetComponent<RectTransform>().localScale.x > 0)
        {
            float y = timebar1.GetComponent<RectTransform>().localScale.y;
            float z = timebar1.GetComponent<RectTransform>().localScale.z;
            timebar1.GetComponent<RectTransform>().localScale = new Vector3(x1 * (Player1Time / 180), y, z);
        }
        else
        {
            timebar1.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
        if (timebar2.GetComponent<RectTransform>().localScale.x > 0)
        {
            float y = timebar2.GetComponent<RectTransform>().localScale.y;
            float z = timebar2.GetComponent<RectTransform>().localScale.z;
            timebar2.GetComponent<RectTransform>().localScale = new Vector3(x2 * (Player1Time / 180), y, z);
        }
        else
        {
            timebar1.GetComponent<RectTransform>().localScale = Vector3.zero;
        }

    }
    int robskill(int stat)
    {

        int specskill = Random.Range(0, skills.Count);
        if ((Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I)))
        {

            if (Input.GetKeyDown(KeyCode.I))
            {
                p2_skill_1.SetActive(true);
                p2_skill_1.GetComponent<Image>().sprite = skills[specskill];
                player2skill[0] = specskill;
            }
            else if (Input.GetKeyDown(KeyCode.O))
            {
                p2_skill_2.SetActive(true);
                p2_skill_2.GetComponent<Image>().sprite = skills[specskill];
                player2skill[1] = specskill;
            }
            else
            {
                p2_skill_3.SetActive(true);
                p2_skill_3.GetComponent<Image>().sprite = skills[specskill];
                player2skill[2] = specskill;
            }
            stat = 0;
            next = true;
        }

        else if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E)))
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                p1_skill_1.SetActive(true);
                p1_skill_1.GetComponent<Image>().sprite = skills[specskill];
                player1skill[0] = specskill;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                p1_skill_2.SetActive(true);
                p1_skill_2.GetComponent<Image>().sprite = skills[specskill];
                player1skill[0] = specskill;
            }
            else
            {
                p1_skill_3.SetActive(true);
                p1_skill_3.GetComponent<Image>().sprite = skills[specskill];
                player1skill[0] = specskill;
            }
            stat = 0;
            next = true;
        }
        else
        {

        }
        return stat;
    }
    void skillchoice()
    {
        //Debug.Log(stat);
        if (stat == 0)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.I))
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    if (!(player2skill[2] == 1 || player2skill[2] == 3 || player2skill[2] == 4 || player2skill[2] == 5 || player2skill[2] == 6 || player2skill[2] == 7 || player2skill[2] == 8 || player2skill[2] == 12))
                        p2_skill_3.GetComponent<Image>().sprite = null;
                    p2_skill_3.SetActive(false);
                    skillRealese(player2skill[2], 2, 2);
                    if (player2skill[2] == 1 || player2skill[2] == 3 || player2skill[2] == 4 || player2skill[2] == 5 || player2skill[2] == 6 || player2skill[2] == 7 || player2skill[2] == 8 || player2skill[2] == 12)
                        p2_skill_3.SetActive(true);
                    //if(player2skill[2] == 1)
                    //{
                    //    p2_state_1.SetActive(false);
                    //    p2_state_2.SetActive(false);
                    //    p2_state_3.SetActive(false);
                    //}
                    //else if(player2skill[2] == 2)
                    //{
                    //    p2_state_3.SetActive(true);
                    //}
                    //else if(player2skill[2] == 16)
                    //{
                    //    p1_state_2.SetActive(true);
                    //}
                    //else if(player2skill[2] == 17 || player2skill[2] == 18 || player2skill[2] == 19)
                    //{
                    //    p1_state_1.SetActive(true);
                    //}
                }
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    if (!(player2skill[1] == 1 || player2skill[1] == 3 || player2skill[1] == 4 || player2skill[1] == 5 || player2skill[1] == 6 || player2skill[1] == 7 || player2skill[1] == 8 || player2skill[1] == 12))
                        p2_skill_2.GetComponent<Image>().sprite = null;
                    p2_skill_2.SetActive(false);
                    skillRealese(player2skill[1], 2, 1);
                    if (player2skill[1] == 1 || player2skill[1] == 3 || player2skill[1] == 4 || player2skill[1] == 5 || player2skill[1] == 6 || player2skill[1] == 7 || player2skill[1] == 8 || player2skill[1] == 12)
                        p2_skill_2.SetActive(true);
                }
                else
                {
                    if (!(player2skill[0] == 1 || player2skill[0] == 3 || player2skill[0] == 4 || player2skill[0] == 5 || player2skill[0] == 6 || player2skill[0] == 7 || player2skill[0] == 8 || player2skill[0] == 12))
                        p2_skill_1.GetComponent<Image>().sprite = null;
                    p2_skill_1.SetActive(false);
                    skillRealese(player2skill[0], 2, 0);
                    if (player2skill[0] == 1 || player2skill[0] == 3 || player2skill[0] == 4 || player2skill[0] == 5 || player2skill[0] == 6 || player2skill[0] == 7 || player2skill[0] == 8 || player2skill[0] == 12)
                        p2_skill_1.SetActive(true);
                }

            }
            else if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.E))
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (!((player1skill[0] == 1 || player1skill[0] == 3 || player1skill[0] == 4 || player1skill[0] == 5 || player1skill[0] == 6 || player1skill[0] == 7 || player1skill[0] == 8 || player1skill[0] == 12)))
                        p1_skill_1.GetComponent<Image>().sprite = null;
                    p1_skill_1.SetActive(false);
                    skillRealese(player1skill[0], 1, 0);
                    if (player1skill[0] == 1 || player1skill[0] == 3 || player1skill[0] == 4 || player1skill[0] == 5 || player1skill[0] == 6 || player1skill[0] == 7 || player1skill[0] == 8 || player1skill[0] == 12)
                        p1_skill_1.SetActive(true);


                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    if (!(player1skill[1] == 1 || player1skill[1] == 3 || player1skill[1] == 4 || player1skill[1] == 5 || player1skill[1] == 6 || player1skill[1] == 7 || player1skill[1] == 8 || player1skill[1] == 12))
                        p1_skill_2.GetComponent<Image>().sprite = null;
                    p1_skill_2.SetActive(false);
                    skillRealese(player1skill[1], 1, 1);
                    if (player1skill[1] == 1 || player1skill[1] == 3 || player1skill[1] == 4 || player1skill[1] == 5 || player1skill[1] == 6 || player1skill[1] == 7 || player1skill[1] == 8 || player1skill[1] == 12)
                        p1_skill_2.SetActive(true);
                    if (player1skill[0] == 1 || player1skill[0] == 3 || player1skill[0] == 4 || player1skill[0] == 5 || player1skill[0] == 6 || player1skill[0] == 7 || player1skill[0] == 8 || player1skill[0] == 12)
                        p1_skill_1.SetActive(true);


                }
                else
                {
                    if (!(player1skill[2] == 1 || player1skill[2] == 3 || player1skill[2] == 4 || player1skill[2] == 5 || player1skill[2] == 6 || player1skill[2] == 7 || player1skill[2] == 8 || player1skill[2] == 12))
                        p1_skill_3.GetComponent<Image>().sprite = null;
                    p1_skill_3.SetActive(false);
                    skillRealese(player1skill[2], 1, 2);
                    if (player1skill[2] == 1 || player1skill[2] == 3 || player1skill[2] == 4 || player1skill[2] == 5 || player1skill[2] == 6 || player1skill[2] == 7 || player1skill[2] == 8 || player1skill[2] == 12)
                        p1_skill_3.SetActive(true);
                    if (player1skill[0] == 1 || player1skill[0] == 3 || player1skill[0] == 4 || player1skill[0] == 5 || player1skill[0] == 6 || player1skill[0] == 7 || player1skill[0] == 8 || player1skill[0] == 12)
                        p1_skill_1.SetActive(true);

                }

            }
            else
            {

            }
        }
    }
    //技能釋放
    void skillRealese(int? skillnum, int player, int index)
    {

        //如果有回避技能狀態，扣點數并且直接跳回Update
        if (player == 1)
        {
            if (avoid_skill_1)
            {
                if (Random.Range(1, 3) % 2 == 0)
                {
                    //6,7,8,12,13,15~20
                    switch (skillnum)
                    {
                        case 6:
                            SkillPoint2 -= 3;
                            break;
                        case 7:
                            SkillPoint2 -= 6;
                            break;
                        case 8:
                            SkillPoint2 -= 9;
                            break;
                        case 12:
                            SkillPoint2 -= 5;
                            break;
                        case 13:
                            SkillPoint2 -= 5;
                            break;
                        case 15:
                            SkillPoint2 -= 12;
                            break;
                        case 16:
                            SkillPoint2 -= 15;
                            break;
                        case 17:
                            SkillPoint2 -= 15;
                            break;
                        case 18:
                            SkillPoint2 -= 18;
                            break;
                        case 19:
                            SkillPoint2 -= 20;
                            break;
                        case 20:
                            SkillPoint2 -= 20;
                            break;
                    }
                    avoidable = true;
                }
                avoid_skill_1 = false;

            }
        }
        else if (player == 2)
        {
            if (avoid_skill_2)
            {
                if (Random.Range(1, 3) % 2 == 0)
                {
                    //6,7,8,12,13,15~20
                    switch (skillnum)
                    {

                        case 6:
                            SkillPoint1 -= 3;
                            break;
                        case 7:
                            SkillPoint1 -= 6;
                            break;
                        case 8:
                            SkillPoint1 -= 9;
                            break;
                        case 12:
                            SkillPoint1 -= 5;
                            break;
                        case 13:
                            SkillPoint1 -= 5;
                            break;
                        case 15:
                            SkillPoint1 -= 12;
                            break;
                        case 16:
                            SkillPoint1 -= 15;
                            break;
                        case 17:
                            SkillPoint1 -= 15;
                            break;
                        case 18:
                            SkillPoint1 -= 18;
                            break;
                        case 19:
                            SkillPoint1 -= 20;
                            break;
                        case 20:
                            SkillPoint1 -= 20;
                            break;
                    }
                    avoidable = true;
                }
                avoid_skill_2 = false;
            }
        }

        //放哪個技能
        if (!avoidable)
        {
            if (skillnum >= 1 && skillnum <= 9)
            {
                s_ele.Play();
            }
            else if (skillnum >= 10 && skillnum <= 17)
            {
                s_adv.Play();
            }
            else
            {
                s_super.Play();
            }
            switch (skillnum)
            {
                case 1:
                    skill_1(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 2:
                    skill_2(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 3:
                    skill_3(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 4:
                    skill_4(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 5:
                    skill_5(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 6:
                    skill_6(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 7:
                    skill_7(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 8:
                    skill_8(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 9:
                    skill_9(player, index);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 10:
                    skill_10(player, index);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 11:
                    skill_11(player, index);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 12:
                    skill_12(player);
                    //if (player == 1) player1skill[index] = null;
                    //else player2skill[index] = null;
                    break;
                case 13:
                    skill_13(player, index);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 14:
                    skill_14(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 15:
                    skill_15(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 16:
                    skill_16(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 17:
                    skill_17(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 18:
                    skill_18(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 19:
                    skill_19(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 20:
                    skill_20(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
                case 21:
                    skill_21(player);
                    if (player == 1) player1skill[index] = null;
                    else player2skill[index] = null;
                    break;
            }
        }
    }
    //清空狀態
    void skill_1(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 2)
            {
                avoid_skill_1 = false;
                logic_1_change = false;
                speed1 = 1;
                SkillPoint1 -= 2;
                p1_state_1.SetActive(false);
                p1_state_2.SetActive(false);
                p1_state_3.SetActive(false);

            }
        }
        else
        {
            if (SkillPoint2 >= 2)
            {
                avoid_skill_2 = false;
                logic_2_change = false;
                speed2 = 1;
                SkillPoint2 -= 2;
                p2_state_1.SetActive(false);
                p2_state_2.SetActive(false);
                p2_state_3.SetActive(false);
            }
        }
    }
    //回避技能
    void skill_2(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 3)
            {

                avoid_skill_1 = true;
                SkillPoint1 -= 3;
                p1_state_3.SetActive(true);
            }
        }
        else
        {
            if (SkillPoint2 >= 3)
            {

                avoid_skill_2 = true;
                SkillPoint2 -= 3;
                p2_state_3.SetActive(true);
            }

        }
    }
    //3~5回血
    void skill_3(int player)
    {

        if (player == 1)
        {
            if (SkillPoint1 >= 3)
            {
                Player1Time += 5;
                SkillPoint1 -= 3;
            }

        }
        else
        {
            if (SkillPoint2 >= 3)
            {
                Player2Time += 5;
                SkillPoint2 -= 3;
            }

        }
    }
    void skill_4(int player)
    {

        if (player == 1)
        {
            if (SkillPoint1 >= 6)
            {
                Player1Time += 10;
                SkillPoint1 -= 6;
            }
        }
        else
        {
            if (SkillPoint2 >= 6)
            {
                Player2Time += 10;
                SkillPoint2 -= 6;
            }
        }
    }
    void skill_5(int player)
    {

        if (player == 1)
        {
            if (SkillPoint1 >= 9)
            {
                Player1Time += 20;
                SkillPoint1 -= 9;
            }
        }
        else
        {
            if (SkillPoint2 >= 9)
            {
                Player2Time += 20;
                SkillPoint2 -= 9;
            }
        }
    }
    //6~8扣敵人血
    void skill_6(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 3)
            {
                Player2Time -= 5;
                SkillPoint1 -= 3;
            }
        }
        else
        {
            if (SkillPoint2 >= 3)
            {
                Player1Time -= 5;
                SkillPoint2 -= 3;
            }
        }
    }
    void skill_7(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 6)
            {
                Player2Time -= 10;
                SkillPoint1 -= 6;
            }
        }
        else
        {
            if (SkillPoint2 >= 6)
            {
                Player1Time -= 10;
                SkillPoint2 -= 6;
            }
        }
    }
    void skill_8(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 9)
            {
                Player2Time -= 20;
                SkillPoint1 -= 9;
            }
        }
        else
        {
            if (SkillPoint2 >= 9)
            {
                Player1Time -= 20;
                SkillPoint2 -= 9;
            }
        }
    }
    void skill_9(int player, int index)
    {
        Debug.Log("hihi1");
        if (player == 1)
        {
            if (SkillPoint1 >= 3)
            {
                int specskill = Random.Range(1, 10);
                player1skill[index] = specskill;
                if (index == 0)
                {
                    p1_skill_1.SetActive(true);
                    p1_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    p1_skill_2.SetActive(true);
                    p1_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    p1_skill_3.SetActive(true);
                    p1_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint1 -= 3;
            }
        }
        else
        {
            if (SkillPoint2 >= 3)
            {
                int specskill = Random.Range(1, 10);
                player2skill[index] = specskill;
                if (index == 0)
                {
                    Debug.Log("hihi");
                    p2_skill_1.SetActive(true);
                    p2_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    Debug.Log("hihi");
                    p2_skill_2.SetActive(true);
                    p2_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    Debug.Log("hihi");
                    p2_skill_3.SetActive(true);
                    p2_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint2 -= 3;
            }
        }
    }
    void skill_10(int player, int index)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 5)
            {
                int specskill = Random.Range(10, 18);
                player1skill[index] = specskill;
                if (index == 0)
                {
                    p1_skill_1.SetActive(true);
                    p1_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    p1_skill_2.SetActive(true);
                    p1_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    p1_skill_3.SetActive(true);
                    p1_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint1 -= 5;
            }
        }
        else
        {
            if (SkillPoint2 >= 5)
            {
                int specskill = Random.Range(10, 18);
                player2skill[index] = specskill;
                if (index == 0)
                {
                    p2_skill_1.SetActive(true);
                    p2_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    p2_skill_2.SetActive(true);
                    p2_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    p2_skill_3.SetActive(true);
                    p2_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint2 -= 5;
            }
        }
    }
    void skill_11(int player, int index)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 5)
            {
                int specskill = Random.Range(18, 22);
                player1skill[index] = specskill;
                if (index == 0)
                {
                    p1_skill_1.SetActive(true);
                    p1_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    p1_skill_2.SetActive(true);
                    p1_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    p1_skill_3.SetActive(true);
                    p1_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint1 -= 5;
            }
        }
        else
        {
            if (SkillPoint2 >= 5)
            {
                int specskill = Random.Range(18, 22);
                player2skill[index] = specskill;
                if (index == 0)
                {
                    p2_skill_1.SetActive(true);
                    p2_skill_1.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else if (index == 1)
                {
                    p2_skill_2.SetActive(true);
                    p2_skill_2.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                else
                {
                    p2_skill_3.SetActive(true);
                    p2_skill_3.GetComponent<Image>().sprite = skills[specskill - 1];
                }
                SkillPoint2 -= 5;
            }
        }
    }
    void skill_12(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 5)
            {
                int specskill = Random.Range(0, 3);
                if (player2skill[specskill] == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (player2skill[i] != null)
                        {
                            specskill = i;
                            if (specskill == 0)
                            {
                                p2_skill_1.SetActive(false);

                            }
                            else if (specskill == 1)
                            {
                                p2_skill_2.SetActive(false);

                            }
                            else
                            {
                                p2_skill_3.SetActive(false);
                            }
                            player2skill[i] = null;
                            break;
                        }

                    }
                }
                else
                {

                    if (specskill == 0)
                    {
                        p2_skill_1.SetActive(false);

                    }
                    else if (specskill == 1)
                    {
                        p2_skill_2.SetActive(false);

                    }
                    else
                    {
                        p2_skill_3.SetActive(false);
                    }
                    player2skill[specskill] = null;
                }
                SkillPoint1 -= 5;

            }
        }
        else
        {
            if (SkillPoint2 >= 5)
            {
                int specskill = Random.Range(0, 3);
                if (player1skill[specskill] == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (player1skill[i] != null)
                        {
                            specskill = i;
                            if (specskill == 0)
                            {
                                p1_skill_1.SetActive(false);

                            }
                            else if (specskill == 1)
                            {
                                p1_skill_2.SetActive(false);

                            }
                            else
                            {
                                p1_skill_3.SetActive(false);
                            }
                            player1skill[i] = null;
                            break;
                        }
                    }
                }
                else
                {
                    if (specskill == 0)
                    {
                        p1_skill_1.SetActive(false);

                    }
                    else if (specskill == 1)
                    {
                        p1_skill_2.SetActive(false);

                    }
                    else
                    {
                        p1_skill_3.SetActive(false);
                    }
                    player1skill[specskill] = null;
                }
                SkillPoint2 -= 5;
            }
        }
    }

    void skill_13(int player, int index)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 5)
            {
                int specskill = Random.Range(0, 3);
                if (player2skill[specskill] != null)
                {
                    player1skill[index] = player2skill[specskill];
                    player2skill[specskill] = null;

                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (player2skill[i] != null)
                        {
                            player1skill[index] = player2skill[i];
                            player2skill[i] = null;
                            specskill = i;
                            break;
                        }
                    }
                }
                int tempskill = (int)player1skill[index];
                if (specskill == 0)
                {
                    p2_skill_1.SetActive(false);

                }
                else if (specskill == 1)
                {
                    p2_skill_2.SetActive(false);

                }
                else
                {
                    p2_skill_3.SetActive(false);
                }
                if (index == 0)
                {
                    p1_skill_1.SetActive(true);
                    p1_skill_1.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                else if (index == 1)
                {
                    p1_skill_2.SetActive(true);
                    p1_skill_2.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                else
                {
                    p1_skill_3.SetActive(true);
                    p1_skill_3.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                SkillPoint1 -= 5;
            }


        }
        else
        {
            if (SkillPoint2 >= 5)
            {
                int specskill = Random.Range(0, 3);
                if (player2skill[specskill] != null)
                {
                    player1skill[index] = player2skill[specskill];
                    player2skill[specskill] = null;

                }
                else
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (player2skill[i] != null)
                        {
                            player1skill[index] = player2skill[i];
                            player2skill[i] = null;
                            specskill = i;
                            break;
                        }
                    }
                }
                int tempskill = (int)player1skill[index];
                if (specskill == 0)
                {
                    p1_skill_1.SetActive(false);

                }
                else if (specskill == 1)
                {
                    p1_skill_2.SetActive(false);

                }
                else
                {
                    p1_skill_3.SetActive(false);
                }
                if (index == 0)
                {
                    p2_skill_1.SetActive(true);
                    p2_skill_1.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                else if (index == 1)
                {
                    p2_skill_2.SetActive(true);
                    p2_skill_2.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                else
                {
                    p2_skill_3.SetActive(true);
                    p2_skill_3.GetComponent<Image>().sprite = skills[tempskill - 1];
                }
                SkillPoint2 -= 5;
            }

        }
    }

    //回血50%
    void skill_14(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 12)
            {
                Player1Time *= 1.5f;
                SkillPoint1 -= 12;
            }
        }
        else
        {
            if (SkillPoint2 >= 12)
            {
                Player2Time *= 1.5f;
                SkillPoint2 -= 12;
            }
        }
    }
    //扣敵人血50%
    void skill_15(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 12)
            {
                Player2Time /= 2;
                SkillPoint1 -= 12;
            }
        }
        else
        {
            if (SkillPoint2 >= 12)
            {
                Player1Time /= 2;
                SkillPoint2 -= 12;
            }
        }
    }
    //邏輯顛倒
    void skill_16(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 15)
            {
                if (logic_2_change == false)
                    logic_2_change = true;
                else
                {
                    logic_2_change = false;
                }
                SkillPoint1 -= 15;
                p2_state_2.SetActive(true);
            }

        }
        else
        {
            if (SkillPoint2 >= 15)
            {
                if (logic_1_change == false)
                    logic_1_change = true;
                else
                {
                    logic_1_change = false;
                }
                SkillPoint2 -= 15;
                p1_state_2.SetActive(true);

            }
        }
    }

    //17~19扣血速度加快
    void skill_17(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 15)
            {
                speed2 *= 1.3f;
                SkillPoint1 -= 15;
                p2_state_1.SetActive(true);

            }
        }
        else
        {
            if (SkillPoint2 >= 15)
            {
                speed1 *= 1.3f;
                SkillPoint2 -= 15;
                p1_state_1.SetActive(true);


            }
        }
    }
    void skill_18(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 18)
            {
                speed2 *= 1.6f;
                SkillPoint1 -= 18;
                p2_state_1.SetActive(true);

            }
        }
        else
        {
            if (SkillPoint2 >= 18)
            {
                speed1 *= 1.6f;
                SkillPoint2 -= 18;
                p1_state_1.SetActive(true);

            }
        }
    }
    void skill_19(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 20)
            {
                speed2 *= 1.9f;
                SkillPoint1 -= 20;
                p2_state_1.SetActive(true);

            }
        }
        else
        {
            if (SkillPoint2 >= 20)
            {
                speed1 *= 1.9f;
                SkillPoint2 -= 20;
                p1_state_1.SetActive(true);

            }
        }
    }

    //對調
    void skill_20(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 20)
            {
                Debug.Log("fuck");
                float tmp;
                tmp = Player1Time;
                Player1Time = Player2Time;
                Player2Time = tmp;
                int?[] tempskill;
                tempskill = player1skill;
                player1skill = player2skill;
                player2skill = tempskill;
                Sprite p1sprite1 = p1_skill_1.GetComponent<Image>().sprite;
                Sprite p1sprite2 = p1_skill_2.GetComponent<Image>().sprite;
                Sprite p1sprite3 = p1_skill_3.GetComponent<Image>().sprite;
                Sprite p2sprite1 = p2_skill_1.GetComponent<Image>().sprite;
                Sprite p2sprite2 = p2_skill_2.GetComponent<Image>().sprite;
                Sprite p2sprite3 = p2_skill_3.GetComponent<Image>().sprite;
                p1_skill_1.SetActive(true);
                p1_skill_1.GetComponent<Image>().sprite = p2sprite1;
                p1_skill_2.SetActive(true);
                p1_skill_2.GetComponent<Image>().sprite = p2sprite2;
                p1_skill_3.SetActive(true);
                p1_skill_3.GetComponent<Image>().sprite = p2sprite3;
                p2_skill_1.GetComponent<Image>().sprite = p1sprite1;
                p2_skill_1.SetActive(true);
                p2_skill_2.GetComponent<Image>().sprite = p1sprite2;
                p2_skill_2.SetActive(true);
                p2_skill_3.GetComponent<Image>().sprite = p1sprite3;
                p2_skill_3.SetActive(true);
                //！換技能！

                float tmp1 = speed1;
                speed1 = speed2;
                speed2 = tmp1;

                if (logic_2_change)
                    logic_1_change = true;
                else
                {
                    logic_1_change = false;
                }

                if (avoid_skill_2)
                    avoid_skill_1 = true;
                else
                {
                    avoid_skill_1 = false;
                }
                SkillPoint1 = (SkillPoint1 + SkillPoint2) / 2;
                SkillPoint2 = SkillPoint1;
            }
        }
        else
        {
            if (SkillPoint2 >= 20)
            {
                float tmp;
                tmp = Player1Time;
                Player1Time = Player2Time;
                Player2Time = tmp;
                int?[] tempskill;
                tempskill = player1skill;
                player1skill = player2skill;
                player2skill = tempskill;
                Sprite p1sprite1 = p1_skill_1.GetComponent<Image>().sprite;
                Sprite p1sprite2 = p1_skill_2.GetComponent<Image>().sprite;
                Sprite p1sprite3 = p1_skill_3.GetComponent<Image>().sprite;
                Sprite p2sprite1 = p2_skill_1.GetComponent<Image>().sprite;
                Sprite p2sprite2 = p2_skill_2.GetComponent<Image>().sprite;
                Sprite p2sprite3 = p2_skill_3.GetComponent<Image>().sprite;
                p1_skill_1.SetActive(true);
                p1_skill_1.GetComponent<Image>().sprite = p2sprite1;
                p1_skill_2.SetActive(true);
                p1_skill_2.GetComponent<Image>().sprite = p2sprite2;
                p1_skill_3.SetActive(true);
                p1_skill_3.GetComponent<Image>().sprite = p2sprite3;
                p2_skill_1.GetComponent<Image>().sprite = p1sprite1;
                p2_skill_1.SetActive(true);
                p2_skill_2.GetComponent<Image>().sprite = p1sprite2;
                p2_skill_2.SetActive(true);
                p2_skill_3.GetComponent<Image>().sprite = p1sprite3;
                p2_skill_3.SetActive(true);
                //！換技能！

                float tmp1 = speed1;
                speed1 = speed2;
                speed2 = tmp1;

                if (logic_2_change)
                    logic_1_change = true;
                else
                {
                    logic_1_change = false;
                }

                if (avoid_skill_2)
                    avoid_skill_1 = true;
                else
                {
                    avoid_skill_1 = false;
                }
                SkillPoint1 = (SkillPoint1 + SkillPoint2) / 2;
                SkillPoint2 = SkillPoint1;
            }
        }
    }

    //重置
    void skill_21(int player)
    {
        if (player == 1)
        {
            if (SkillPoint1 >= 20)
            {
                int specskill = Random.Range(1, 10);
                p1_skill_1.GetComponent<Image>().sprite = skills[specskill];
                p1_skill_1.SetActive(true);
                player1skill[0] = specskill;
                specskill = Random.Range(1, 10);

                p1_skill_2.GetComponent<Image>().sprite = skills[specskill];
                p1_skill_2.SetActive(true);
                player1skill[1] = specskill;
                specskill = Random.Range(1, 10);

                p1_skill_3.GetComponent<Image>().sprite = skills[specskill];
                p1_skill_3.SetActive(true);
                player1skill[2] = specskill;
                //！！技能隨機！！
                Player1Time = 180;
                SkillPoint1 = 0;
            }
        }
        else
        {
            if (SkillPoint2 >= 20)
            {
                int specskill = Random.Range(1, 10);
                p2_skill_1.GetComponent<Image>().sprite = skills[specskill];
                p2_skill_1.SetActive(true);
                player2skill[0] = specskill;
                specskill = Random.Range(1, 10);

                p2_skill_2.GetComponent<Image>().sprite = skills[specskill];
                p2_skill_2.SetActive(true);
                player2skill[1] = specskill;
                specskill = Random.Range(1, 10);

                p2_skill_3.GetComponent<Image>().sprite = skills[specskill];
                p2_skill_3.SetActive(true);
                player2skill[2] = specskill;
                //！！技能隨機！！
                Player2Time = 180;
                SkillPoint2 = 0;
            }
        }
    }

    public static List<T> Shuffle<T>(List<T> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            T temp = cards[i];
            int randomIndex = Random.Range(i, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }

        return cards;
    }

    public void Convert(Text m_ClockText, float m_Timer)
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
}