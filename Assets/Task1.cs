using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    string[] playerFirstNames = new string[19];
    string[] playerLastNames = new string[25];

    Queue<string> initialLogin;

    // Start is called before the first frame update
    void Start()
    {
        SetFirstNames();
        SetLastNames();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetFirstNames()
    {
        playerFirstNames[0] = "Bob";
    }

    private void SetLastNames()
    {
        playerLastNames[0] = "A";
        playerLastNames[1] = "B";
    }
}
