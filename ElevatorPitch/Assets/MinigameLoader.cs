using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Written by Santiago Ponce
//saponce@ucsc.edu

public class MinigameLoader : MonoBehaviour
{
    public int maxTime;
    public Text textDisplay = null;
    string instructions = "";
    public int firstMinigame = 1;

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

        //Add more instructions when adding new minigames
        int cubicleRush = firstMinigame;
        if(nextGame == cubicleRush + 0) //Cubicle rush
        {
            instructions = "Get to your cubicle!";
        }
        else //Unknown minigame
        {
            instructions = "Get ready!";
        }

        StartCoroutine(waitTime(nextGame));
    }

    IEnumerator waitTime(int scene)
    {
        //Debug.Log(scene);
        yield return new WaitForSeconds(0.5f);
        textDisplay.text = instructions; //Display instructions

        while (maxTime> 0)
        {
            yield return new WaitForSeconds(1); //Wait a few seconds
            maxTime--;
        }
        //Debug.Log("Loading next scene");
        SceneManager.LoadScene(scene); //Load scene
    }
}
