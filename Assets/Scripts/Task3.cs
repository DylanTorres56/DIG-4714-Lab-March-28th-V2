using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    // We are doing a small game that plays by itself.
    // A card deck with only honor cards (16 total)

    // Create a random deck
    // Check if you have a set of 3 suits

    // If yes, the game is won
    // If no, discard a random card from hand and draw another one
    // If cards are finished, the game is lost

    bool winningHand;
    string gameResult;        

    Stack<string> deck = new Stack<string>();
    string[] shuffledDeck = new string[15];
    string[] thisHand = new string[3];

    Stack<string> hand = new Stack<string>();
    string tempCard;

    string[] cardHonor = new string[]
    {
        "King",
        "Queen",
        "Jack",
        "Ace"
    };

    string[] cardSuit = new string[]
    {
        " of Clubs",
        " of Spades",
        " of Hearts",
        " of Diamonds"
    };

    // Start is called before the first frame update
    void Start()
    {
        CreateDeck();
        ShuffleDeck();
        DrawFirstHand();

        if (deck.Count != 0 && !winningHand) 
        {
            InvokeRepeating("DrawNextHand", 1, 1);
        }
    }

    void CreateDeck()
    {
        for (int i = 0; i < cardHonor.Length; i++)
        {
            for (int j = 0; j < cardHonor.Length; j++)
            {
                deck.Push(cardHonor[i] + cardSuit[j]);
            }
        }

    }

    void ShuffleDeck()
    {
        shuffledDeck = deck.ToArray();

        for (int i = 0; i < shuffledDeck.Length; i++)
        {
            int randomCard = Random.Range(i, shuffledDeck.Length);
            tempCard = shuffledDeck[randomCard];
            shuffledDeck[randomCard] = shuffledDeck[i];
            shuffledDeck[i] = tempCard;
        }


    }

    void DrawFirstHand()
    {
        for (int i = 0; i < 3; i++) 
        {
            hand.Push(shuffledDeck[i]);
            thisHand[i] = shuffledDeck[i];
        }

        WinCheck();

        Debug.LogFormat("I made the initial deck and draw. \nMy hand is: {0}, {1}, {2} and {3}. {4}", 
            shuffledDeck[0], shuffledDeck[1], shuffledDeck[2], shuffledDeck[3], gameResult);

    }

    void DrawNextHand() 
    {
        string newDraw = deck.Pop();
        string replacedDraw;

        for (int i = 0; i < thisHand.Length; i++) 
        {
            thisHand[i] = shuffledDeck[i];
        }

        int randomDiscard = Random.Range(0, thisHand.Length);

        replacedDraw = shuffledDeck[randomDiscard];
        shuffledDeck[randomDiscard] = newDraw;

        hand.Push(newDraw);

        WinCheck();

        Debug.LogFormat("I discarded {0} and added {1}. \nMy hand is: {2}, {3}, {4} and {5}. {6}",
            replacedDraw, newDraw, shuffledDeck[0], shuffledDeck[1], shuffledDeck[2], shuffledDeck[3], gameResult);

    }

    void WinCheck() 
    {
        HashSet<string> thisHandHash = thisHand.ToHashSet();

        HashSet<string> clubHash = new HashSet<string>()
        {
            "King of Clubs",
            "Queen of Clubs",
            "Jack of Clubs",
            "Ace of Clubs"
        };

        HashSet<string> spadeHash = new HashSet<string>()
        {
            "King of Spades",
            "Queen of Spades",
            "Jack of Spades",
            "Ace of Spades"
        };

        HashSet<string> heartHash = new HashSet<string>()
        {
            "King of Hearts",
            "Queen of Hearts",
            "Jack of Hearts",
            "Ace of Hearts"
        };

        HashSet<string> diamondHash = new HashSet<string>()
        {
            "King of Diamonds",
            "Queen of Diamonds",
            "Jack of Diamonds",
            "Ace of Diamonds"
        };

        clubHash.IntersectWith(thisHandHash);
        spadeHash.IntersectWith(thisHandHash);
        heartHash.IntersectWith(thisHandHash);
        diamondHash.IntersectWith(thisHandHash);

        if (clubHash.Count > 2 || spadeHash.Count > 2 || heartHash.Count > 2 || diamondHash.Count > 2)
        {
            winningHand = true;
        }
        else 
        {
            winningHand = false;
        }

        Debug.Log(clubHash.Count);
        Debug.Log(spadeHash.Count);
        Debug.Log(heartHash.Count);
        Debug.Log(diamondHash.Count);

        if (winningHand)
        {
            gameResult = "The game is WON.";
        }
        else
        {
            gameResult = "This is not a winning hand.";
        }
    }
}
