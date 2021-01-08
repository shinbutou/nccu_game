using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    //Deck Images
    public Sprite C_A, C_2, C_3, C_4, C_5, C_6, C_7, C_8, C_9, C_10, C_J, C_Q, C_K;
    public Sprite D_A, D_2, D_3, D_4, D_5, D_6, D_7, D_8, D_9, D_10, D_J, D_Q, D_K;
    public Sprite H_A, H_2, H_3, H_4, H_5, H_6, H_7, H_8, H_9, H_10, H_J, H_Q, H_K;
    public Sprite S_A, S_2, S_3, S_4, S_5, S_6, S_7, S_8, S_9, S_10, S_J, S_Q, S_K;
    public Sprite J_0, J_1;

    //Deck Initialization
    public int[][] Deck = new int[65][];
    private int[] spare = new int[3];

    //Script Initialization
    public MainController Main;

    void Start()
    {
        Main = GameObject.FindWithTag("GameController").GetComponent<MainController>();

        for (int i = 0; i < 65; i++)
        {
            //Construction
            Deck[i] = new int[3];
            if (i <= 12)
            {
                Deck[i][0] = 1; //Club
                Deck[i][1] = i;
                Deck[i][2] = 0; //Blue
                //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
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
        Shuffle(Deck);
        Main.Game(Deck);
    }

    void Update(){}

    void PrintDeck(int[][] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            Debug.Log(cards[i][0].ToString() + ", " + cards[i][1].ToString() + ", " + cards[i][2].ToString() + ", " + i.ToString());
        }
    }

    /*
    void PrintArray(int[] array, int i)
    {
        Debug.Log(array[0].ToString() + ", " + array[1].ToString() + ", " + array[2].ToString() + ", " + i.ToString());
    }
    */

    void Shuffle(int[][] cards)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            spare = cards[i];
            int j = Random.Range(i, cards.Length);
            cards[i] = cards[j];
            cards[j] = spare;
            //Debug.Log(Deck[i][0].ToString() + ", " + Deck[i][1].ToString() + ", " + Deck[i][2].ToString());
            //Debug.Log(Deck[j][0].ToString() + ", " + Deck[j][1].ToString() + ", " + Deck[j][2].ToString());
            //Debug.Log(spare[0].ToString() + ", " + spare[1].ToString() + ", " + spare[2].ToString());
        }
    }
}
