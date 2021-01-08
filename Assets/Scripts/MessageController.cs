using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    // Answer Results
    public GameObject P1_correct;
    public GameObject P2_correct;
    public GameObject P1_wrong;
    public GameObject P2_wrong;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int test = Random.Range(0, 2);
            Debug.Log(test);
        }   
    }
}
