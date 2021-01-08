using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    Color yellow;
    Color purple;
    Color red;
    Color orange;
    Color green;
    Color blue;

    float timer;
    float timenow;
    public Text t;

    void Start()
    {
        t.color = new Color(0, 0, 0, 0);
        yellow = new Color(255, 255, 0);
        red = new Color(255, 0, 0);
        green = new Color(0, 255, 255);
        blue = new Color(0, 0, 255);
        purple = new Color(255, 0, 255);
        orange = new Color(255, 137, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(0);
        }

        if (GameObject.Find("GameControl").GetComponent<MainController>().haswinner)
        {

            // GameObject.Find("GameControl").GetComponent<game>().enabled = false;
            if (GameObject.Find("GameControl").GetComponent<MainController>().winner_player == 0)
            {
                t.text = "   Draw";
            }
            else if (GameObject.Find("GameControl").GetComponent<MainController>().winner_player == 1)
            {
                t.text = "Player1 win";
            }
            else
            {
                t.text = "Player2 win";
            }
            timer += Time.deltaTime;

            if (timer - timenow >= 1f)
            {
                timenow = timer;
                int num = Random.Range(0, 6);
                switch (num)
                {
                    case 0:
                        t.color = red;
                        break;
                    case 1:
                        t.color = orange;
                        break;
                    case 2:
                        t.color = yellow;
                        break;
                    case 3:
                        t.color = green;
                        break;
                    case 4:
                        t.color = blue;
                        break;
                    case 5:
                        t.color = purple;
                        break;
                }
            }
        }
    }
}
