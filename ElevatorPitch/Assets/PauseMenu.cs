using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseText; //UI canvas that tells you the game is paused (attached to PersistantData, like this script)
    public static int playerPause;
    public Text textDisplay = null;

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused
        if(Time.timeScale == 0)
        {
            pauseText.SetActive(true);
            textDisplay.text = "P" + playerPause + " Pause";
        }
        else
        {
            pauseText.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Button pressed");
        Application.Quit();
    }
}
