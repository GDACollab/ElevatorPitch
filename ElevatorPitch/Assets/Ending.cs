using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Tilemaps;

//Written by Santiago Ponce
//Some code borrowed from VNManager by Jacob Compton

public class Ending : MonoBehaviour
{
    public GameObject[] endingCards = new GameObject[4];
    persistentData persistentData;
    int[] placement = new int[4]; //This array will hold each player's index in their designated placement (0 = 1st place, 1 = 2nd place, etc.)
    TextMeshProUGUI dialogue;
    string[] dialogueSequence = new string[3];
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
        dialogue = GameObject.FindGameObjectWithTag("vnCharacterSpeechText").GetComponent<TextMeshProUGUI>(); //Get name text box
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        if (persistentData && dialogue)
        {
            Debug.Log("Found Pers Data");
            
            //Assign each player to a placement rank
            float max = Mathf.Infinity;
            int next = -200;
            bool[] skip = new bool[4];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    if(persistentData.scores[j] >= next && !skip[j]) //Ties are based on port-priority
                    {
                        next = persistentData.scores[j];
                        placement[i] = j;
                    }
                }
                max = next;
                next = -200;
                skip[placement[i]] = true;
            }

            //Choose winner randomly if there is a tie
            int winners = 0;
            int bestScore = persistentData.scores[placement[0]];
            for(int i = 0; i < 4; i++)
            {
                if(persistentData.scores[i] == bestScore)
                {
                    winners++;
                }
            }
            if(winners > 1) //There is a tie
            {
                int tiebreaker = UnityEngine.Random.Range(0, winners);
                int winner = placement[tiebreaker];
                placement[tiebreaker] = placement[0]; //Swap randomly chosen winner with top
                placement[0] = winner;
            }

            //Set dialogue. Can be expanded later.
            dialogue.text = "Congratulations, you reached the top floor!\n" + 
                            "For performing the best overall, the new CEO is " + getPlayerName(placement[0]) + "!";

            //Dialogue sequence. If we don't want to show scores then just erase some of this.
            dialogueSequence[0] = "After countless chaotic floors, the group finally reaches the top and meets the CEO.";
            dialogueSequence[1] = "For performing the best overall, " + getPlayerName(placement[0]) + " is chosen as the new CEO.";
            dialogueSequence[2] = "Congradulations Player " + (placement[0] + 1) + "! You scored " + persistentData.scores[placement[0]] + " points.\n" +
                                  "2nd Place: " + getPlayerName(placement[1]) + " with " + persistentData.scores[placement[1]] + " points.\n" +
                                  "3rd Place: " + getPlayerName(placement[2]) + " with " + persistentData.scores[placement[2]] + " points.\n" +
                                  "4th Place: " + getPlayerName(placement[3]) + " with " + persistentData.scores[placement[3]] + " points.\n " +
                                  "Press A or SPACEBAR to play again.";

            //Set ending card
            endingCards[placement[0]].SetActive(true);

            StartCoroutine(waitTime());
        }
        else
        {
            Debug.Log("Ending ERROR: Did not find Pers Data");
        }
    }

    IEnumerator waitTime()
    {
        mainCamera.transform.position = new Vector3(-11.67f, 0.21f, -10f);
        mainCamera.orthographicSize = 4.5f;
        dialogue.text = dialogueSequence[0];
        yield return new WaitForSeconds(5);

        mainCamera.transform.position = new Vector3(-11.8f, -8.04f, -10f);
        mainCamera.orthographicSize = 5.7305f;

        dialogue.text = dialogueSequence[1];
        yield return new WaitForSeconds(5);

        mainCamera.transform.position = new Vector3(-0.41f, -2.08f, -10f);
        mainCamera.orthographicSize = 6.43f;
        dialogue.text = dialogueSequence[2];
        persistentData.ending = true;
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
