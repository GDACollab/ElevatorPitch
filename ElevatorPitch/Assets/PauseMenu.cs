using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseText; //UI canvas that tells you the game is paused (attached to PersistantData, like this script)
    public static int playerPause;
    public Text textDisplay = null;

    public Image[] buttons = new Image[5];

    public Animator doors;

    public static int cursorPosition; //Controls which option is being hovered over

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused
        if(Time.timeScale == 0)
        {
            doors.SetBool("Close Doors", true);
            pauseText.SetActive(true);
            textDisplay.text = "P" + playerPause + " Pause";
        }
        else
        {
            doors.SetBool("Close Doors", false);
            pauseText.SetActive(false);
        }

        //Check for cursor position
        
    }

    public void QuitGame()
    {
        Debug.Log("Button pressed");
        Application.Quit();
    }
}
