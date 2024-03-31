using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : MonoBehaviour
{

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

    string[] randomNameList = new string[15];
    HashSet<string> randomNames = new HashSet<string>();
    HashSet<string> duplicateNames = new HashSet<string>();
    string firstName;

    bool ArrayPredicate(HashSet<string> thisHash, string thisFirstName)
    {
        return thisHash.Contains(thisFirstName);
    }

    private void Start()
    {
        for(int i = 0; i < randomNameList.Length; i++)
        {
            int randomIndexNum = Random.Range(0, 19);
            randomNameList[i] = playerFirstNames[randomIndexNum];
            firstName = randomNameList[i];

            if (ArrayPredicate(randomNames, firstName) == false)
            {
                randomNames.Add(firstName);
            }
            else 
            {
                duplicateNames.Add(firstName);
            }


        }

        Debug.Log("Created the name array:");

        foreach (string foundName in randomNameList)
        {
            Debug.Log(foundName);
        }
        
        Debug.Log("The array has duplicate names:");
        foreach (string dupeName in duplicateNames)
        {
            Debug.Log(dupeName);
        }

    }
            
}