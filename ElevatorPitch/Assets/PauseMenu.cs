using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseText; //UI canvas that tells you the game is paused (attached to PersistantData, like this script)
    public static int playerPause;
    public Text textDisplay = null;
    public Text buttonFunction = null;

    public GameObject[] buttons = new GameObject[5];

    //public Animator doors;

    public static int cursorPosition; //Controls which option is being hovered over
    public static bool muted = false;
    public static bool justPaused = false;
    public string volumeText; //This should be whatever the default volume is

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused
        if (Time.timeScale == 0 && justPaused)
        {
            //doors.SetBool("Close Doors", true);
            pauseText.SetActive(true);
            textDisplay.text = "P" + playerPause + " Pause";

            //Set button elements to default
            //First button = active, 
            cursorPosition = 0;
            buttons[0].SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                buttons[i].SetActive(false);
            }
            justPaused = false;
        }
        else if(Time.timeScale == 1)
        {
            //doors.SetBool("Close Doors", false);
            pauseText.SetActive(false);
        }

        //Check for cursor position
        if (cursorPosition == 0) //Highlight resume
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[0].SetActive(true);
            buttonFunction.text = "Resume";
        }
        else if (cursorPosition == 1 && !muted) //Highlight sound
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[1].SetActive(true);
            buttonFunction.text = volumeText;
        }
        else if (cursorPosition == 1 && muted) //Highlight mute
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[3].SetActive(true);
            buttonFunction.text = volumeText;
        }
        else if (cursorPosition == 2) //Highlight exit
        {
            for (int i = 0; i < 4; i++)
            {
                buttons[i].SetActive(false);
            }
            buttons[2].SetActive(true);
            buttonFunction.text = "Quit Game";
        }

        if(muted)
        {
            buttons[4].SetActive(true);
        }
        else
        {
            buttons[4].SetActive(false);
        }
    }

    public static void select()
    {
        
    }

    public void QuitGame()
    {
        Debug.Log("Button pressed");
        //Application.Quit();
    }
}
