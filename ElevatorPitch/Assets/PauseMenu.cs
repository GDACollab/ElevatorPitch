using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseText; //UI canvas that tells you the game is paused (attached to PersistantData, like this script)

    // Update is called once per frame
    void Update()
    {
        //Check if game is paused
        if(Time.timeScale == 0)
        {
            pauseText.SetActive(true);
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
