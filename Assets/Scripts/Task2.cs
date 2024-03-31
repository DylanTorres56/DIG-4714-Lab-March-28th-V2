using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

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

    string[] randomnamelist = new string[15];
    HashSet<string> randomnames = new HashSet<string>();
    HashSet<string> duplicatenames = new HashSet<string>();
    string firstName;

    private void Start()
    {
        for(int i=0; i<randomnamelist.Length; i++)
        {
            int index = Random.Range(0, 19);
            randomnamelist[i] = playerFirstNames[index];
            firstName = randomnamelist[i];
            randomnames.Add(firstName);	
        }

        for (int i = 0; i < randomnamelist.Length; i++)
        {
            firstName = randomnamelist[i];

            if (!randomnames.Add(firstName))
            {
                duplicatenames.Add(firstName);
            }
        }

        Debug.Log("Created the name array:");

        foreach (string foundName in randomnamelist)
        {
            Debug.Log(foundName);
        }
        
        Debug.Log("The array has duplicate names:");
        foreach (string dupeName in duplicatenames)
        {
            Debug.Log(dupeName);
        }

    }
            
}