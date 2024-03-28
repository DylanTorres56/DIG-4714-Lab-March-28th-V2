using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{
    string[] playerFullNames = new string[19];
    string[] playerFirstNames = new string[19];
    string[] playerLastNames = new string[2];

    Queue<string> initialLogin;

    // Start is called before the first frame update
    void Start()
    {
        SetFirstNames();
        SetLastNames();
        CombineNames();
    }

    private void SetFirstNames()
    {
        playerFirstNames[0] = "Bob";
        playerFirstNames[1] = "Rob";
        playerFirstNames[2] = "Cob";
        playerFirstNames[3] = "Lob";
        playerFirstNames[4] = "Gob";
        playerFirstNames[5] = "Wob";
        playerFirstNames[6] = "Nob";
        playerFirstNames[7] = "Pob";
        playerFirstNames[8] = "Zob";
        playerFirstNames[9] = "Mob";
        playerFirstNames[10] = "Hob";
        playerFirstNames[11] = "Tob";
        playerFirstNames[12] = "Vob";
        playerFirstNames[13] = "Job";
        playerFirstNames[14] = "Yob";
        playerFirstNames[15] = "Fob";
        playerFirstNames[16] = "Mike";
        playerFirstNames[17] = "Bike";
        playerFirstNames[18] = "Sike";
        playerFirstNames[19] = "Yike";
    }

    private void SetLastNames()
    {
        playerLastNames[0] = "A";
        playerLastNames[1] = "B";
        playerLastNames[2] = "C";
    }

    private void CombineNames() 
    {

        for (int i = 0; i < playerFirstNames.Length; i++)
        {
            playerFullNames[i] = playerFirstNames[Random.RandomRange(0, 19)] + " " + playerLastNames[Random.RandomRange(0, 2)];
        }
    }
}
