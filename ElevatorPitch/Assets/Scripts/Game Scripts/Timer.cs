using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text textDisplay = null;
    // Start is called before the first frame update
    public int maxTime = 10;
    public bool showTimer = true;
    private GameObject persistentDataObj;
    private persistentData persistentDataScript;
    private GameObject gameMode;
    private WinCondition winCondition;
    //private GameObject winCondition;

    //Animation of elevator doors
    public Animator transition;

    void Start()
    {
        persistentDataObj = GameObject.FindGameObjectWithTag("persData");
        persistentDataScript = persistentDataObj.GetComponent<persistentData>();
        gameMode = GameObject.FindGameObjectWithTag("GameMode");

        winCondition = gameMode.GetComponent<WinCondition>();
        textDisplay.text = "";
        if (showTimer)
        {
            textDisplay.text = "Time: " + maxTime.ToString();
        }
        if(!(SceneManager.GetActiveScene().name == "Start")){
            StartCoroutine(waitTime());
        }
    }


    //timer algorithm (source: https://stackoverflow.com/questions/30056471/how-make-the-script-wait-sleep-in-a-simple-way-in-unity)
    IEnumerator waitTime()
    {
        float timeSet = maxTime;
        while (timeSet > 0)
        {
            yield return new WaitForSeconds(0.1f);
            //Debug.Log(timeSet);
            timeSet -= 0.1f;
            timeSet *= 10;
            timeSet = Mathf.Floor(timeSet);
            timeSet /= 10;
            if (showTimer)
            {
                textDisplay.text = "Time: " + timeSet.ToString();
            }
        }

        winCondition.goalCompletionCheck(winCondition.gameModeTemplate);
        //winCondition.GetComponent<WinCondition>().goalCompletionCheck(winCondition.GetComponent<WinCondition>().gameModeTemplate);


        //Added by Santiago. Does the elevator door animation before loading next level
        transition.SetTrigger("Close Doors");
        yield return new WaitForSeconds(0.8f);

        persistentDataScript.nextLevel();
    }


    public void doTransition(){
        StartCoroutine(closeDoors());
    }

    IEnumerator closeDoors(){
        transition.SetTrigger("Close Doors");
        yield return new WaitForSeconds(0.8f);
        persistentDataScript.nextLevel();
    }
}
