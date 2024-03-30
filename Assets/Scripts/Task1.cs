using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : MonoBehaviour
{

    Queue<string> playerFullNames = new Queue<string>();

    string[] playerFirstNames = new string[]
    {
        "Bob",
        "Rob",
        "Cob",
        "Lob",
        "Gob",
        "Wob",
        "Nob",
        "Pob",
        "Zob",
        "Hob",
        "Mob",
        "Tob",
        "Vob",
        "Job",
        "Yob",
        "Fob",
        "Mike",
        "Bike",
        "Sike",
        "Yike"
    };

    string[] playerLastNames = new string[]
    {
        " A.",
        " B.",
        " C.",
        " D.",
        " E.",
        " F.",
        " G.",
        " H.",
        " I.",
        " J.",
        " K",
        " L.",
        " M.",
        " N.",
        " O.",
        " P.",
        " Q.",
        " R.",
        " S.",
        " T.",
        " U.",
        " V.",
        " W.",
        " X.",
        " Y.",
        " Z.",
    };

    Queue<string> initialLogin = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        CombineNames();
        Invoke("InitializeLoginQueue", 1);
        InvokeRepeating("PresentNames", 2, 1);
    }

    // First name is combined with a random last name initial to create a full name that is then added to a queue.
    private void CombineNames() 
    {        
        for (int i = 0; i < playerFirstNames.Length; i++)
        {
            playerFullNames.Enqueue(playerFirstNames[i] + playerLastNames[(Random.Range(0, playerLastNames.Length))]);            
        }    
        
    }

    // First 5 names are added to the initial login queue.
    private void InitializeLoginQueue() 
    {
        for (int i = 0; i < 5; i++) 
        {
            string initialFullName = playerFullNames.Dequeue();
            initialLogin.Enqueue(initialFullName);
        }

        Debug.LogFormat("Initial login queue created. There are {0} players inside the queue: ", initialLogin.Count);
        foreach (string loginFullName in initialLogin) 
        {
            Debug.Log(loginFullName);
        }
    }

    // Initial login queue has users who log into the game successfully and are removed until there are none left to remove.
    // More last names are added to the queue from the playerFullNames queue until there are none left to add.
    private void PresentNames() 
    {
               
        if (initialLogin.Count != 0) 
        {
            string fullName = initialLogin.Dequeue();
            
            if (playerFullNames.Count != 0)
            {
                string nextNameToQueue = playerFullNames.Dequeue();        
                initialLogin.Enqueue(nextNameToQueue);
                Debug.LogFormat("{0} is now inside the game. \n{1} is trying to log in and has been added to the queue.", fullName, nextNameToQueue);
            }

            else 
            {
                Debug.LogFormat("{0} is now inside the game. \nThere are no players left to be added to queue.", fullName);
            }

        }
        
    }
}
