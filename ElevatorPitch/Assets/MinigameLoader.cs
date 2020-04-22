﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Written by Santiago Ponce
//saponce@ucsc.edu

public class MinigameLoader : MonoBehaviour
{
    public float maxTime;
    public Text textDisplay = null;
    string instructions = "";
    public int firstMinigame = 1;
    public GameObject[] text = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {

        /* Chooses next game with a random number
         * Starts at 1 because 0 is the transition scene.
         * Important: If more non-minigame scenes are added, make sure to adjust the firstMinigame variable 
         * to make sure they are not selected by accident
         * */
        //Debug.Log(SceneManager.sceneCountInBuildSettings);
        int nextGame = Random.Range(firstMinigame, SceneManager.sceneCountInBuildSettings);
        foreach (var x in text)
        {
            if (x != null) x.SetActive(false);
        }
        //Add more instructions when adding new minigames
        int cubicleRush = firstMinigame;
        int displayText = nextGame - cubicleRush + 1;

        if (displayText >= text.Length) //Minigame does not have a text object
        {
            displayText = 0;
        }
        text[displayText].SetActive(true);

        /*
        if(nextGame == cubicleRush + 0) //Cubicle rush
        {
            //instructions = "Get to your cubicle!";
            text[nextGame].SetActive(true);

        } else if (nextGame == cubicleRush + 1)
        {
            //instructions = "SURVIVE!";
            text[nextGame].SetActive(true);
        } else if (nextGame == cubicleRush + 2)
        {
            //instructions = "DODGE!";
            text[nextGame].SetActive(true);
        }
        else //Unknown minigame
        {
            instructions = "Get ready!";
        }
        */

        StartCoroutine(waitTime(nextGame, displayText));
    }

    IEnumerator waitTime(int scene, int displayText)
    {
        //Debug.Log(scene);
        yield return new WaitForSeconds(0.3f);
        //textDisplay.text = instructions; //Display instructions
        bool toggle = true;
        while (maxTime > 0)
        {
            yield return new WaitForSeconds(0.3f); //Wait a few seconds
            if (toggle)
            {
                text[displayText].SetActive(false);
                toggle = false;
            }
            else
            {
                text[displayText].SetActive(true);
                toggle = true;
            }
            maxTime -= 0.3f;
        }
        //Debug.Log("Loading next scene");
        SceneManager.LoadScene(scene); //Load scene
    }
}
