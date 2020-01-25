using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textDisplay = null;
    // Start is called before the first frame update
    public int maxTime = 10;

    void Start()
    {
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
    }
}
