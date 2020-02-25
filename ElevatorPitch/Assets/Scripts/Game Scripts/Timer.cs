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

    //Animation of elevator doors
    public Animator transition;

    void Start()
    {
        persistentDataObj = GameObject.FindGameObjectWithTag("persData");
        persistentDataScript = persistentDataObj.GetComponent<persistentData>();
        textDisplay.text = "Time: " + maxTime.ToString();
        StartCoroutine(waitTime());
    }
    //timer algorithm (source: https://stackoverflow.com/questions/30056471/how-make-the-script-wait-sleep-in-a-simple-way-in-unity)
    IEnumerator waitTime()
    {
        int timeSet = maxTime;
        while (timeSet > 0)
        {
            yield return new WaitForSeconds(1);
            //Debug.Log(timeSet);
            timeSet--;
            textDisplay.text = "Time: " + timeSet.ToString();
        }

        //Added by Santiago. Does the elevator door animation before loading next level
        transition.SetTrigger("Close Doors");
        yield return new WaitForSeconds(1);
        persistentDataScript.nextLevel();
    }
}
