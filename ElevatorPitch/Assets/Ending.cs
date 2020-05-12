using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Written by Santiago Ponce
//Some code borrowed from VNManager by Jacob Compton

public class Ending : MonoBehaviour
{
    public GameObject[] endingCards = new GameObject[4];
    persistentData persistentData;
    int[] placement = new int[4]; //This array will hold each player's index in their designated placement (0 = 1st place, 1 = 2nd place, etc.)
    TextMeshProUGUI dialogue;

    // Start is called before the first frame update
    void Start()
    {
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
        dialogue = GameObject.FindGameObjectWithTag("vnCharacterSpeechText").GetComponent<TextMeshProUGUI>(); //Get name text box

        if (persistentData && dialogue)
        {
            Debug.Log("Found Pers Data");
            
            //Assign each player to a placement rank
            float max = Mathf.Infinity;
            int next = -200;
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(persistentData.scores[j] > next && persistentData.scores[j] < max) //Ties are based on port-priority
                    {
                        next = persistentData.scores[j];
                        placement[i] = j;
                    }
                }
                max = next;
            }

            //Set dialogue. Can be expanded later.
            dialogue.text = "Congratulations, you reached the top floor!\n" + 
                            "The winner is " + getPlayerName(placement[0]) + "!";

            //Set ending card
            endingCards[placement[0]].SetActive(true);
        }
        else
        {
            Debug.Log("Ending ERROR: Did not find Pers Data");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Returns the name of the corresponding player. Pretty simple.
    string getPlayerName(int player)
    {
        if(player == 0)
        {
            return "Blake Blaze (P1)";
        }
        else if(player == 1)
        {
            return "Giang Gage (P2)";
        }
        else if(player == 2)
        {
            return "Robin Robyn (P3)";
        }
        else if(player == 3)
        {
            return "Ya Yi Yeet (P4)";
        }
        else
        {
            return "You were expecting a player, but it was me, Dio!";
        }
    }
}
