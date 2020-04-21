using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textDisplay = null;
    // Start is called before the first frame update
    public int maxTime = 10;
    private GameObject persistentDataObj;
    private persistentData persistentDataScript;
    private WinCondition winCondition;

    //Animation of elevator doors
    public Animator transition;

    void Start()
    {
        persistentDataObj = GameObject.FindGameObjectWithTag("persData");
        persistentDataScript = persistentDataObj.GetComponent<persistentData>();
        winCondition = persistentDataObj.GetComponent<WinCondition>();
        textDisplay.text = "Time: " + maxTime.ToString();
        StartCoroutine(waitTime());
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
            textDisplay.text = "Time: " + timeSet.ToString();
        }

        winCondition.goalCompletionCheck(winCondition.gameModeTemplate);


        //Added by Santiago. Does the elevator door animation before loading next level
        transition.SetTrigger("Close Doors");
        yield return new WaitForSeconds(0.8f);

        persistentDataScript.nextLevel();
    }
}
