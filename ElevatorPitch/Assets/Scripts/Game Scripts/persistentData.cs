using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persistentData : MonoBehaviour
{
    //initializing variables
    public static persistentData main;
    public int[] scores = new int[4];
    public float[] finishTimes = new float[4];
    public bool[] complete = new bool[4];
    //int floorNum;
    float timerStartPoint;
    private AudioSource audioSource;
    //private Timer timer;

    void Start()
    {
        //floorNum = 0;
        scores[0] = 0;
        scores[1] = 0;
        scores[2] = 0;
        scores[3] = 0;
        //finishTimes[0] = 0;
        //finishTimes[1] = 0;
        //finishTimes[2] = 0;
        //finishTimes[3] = 0;
        

    }

   
    //singleton pattern
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        //timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        } else
        {
            audioSource.Stop();
        }
        if(main == null)
        {
            main = this;
            DontDestroyOnLoad(transform);
        } else {
            Destroy(this.gameObject);
        }
    }


    void OnPlayerJoined()
    {
        Debug.Log("PLAYER JOINED");
    }

    //any functions needed for getting or setting data
    //ex:

    //public void updateScores(int x)
    //{ //this function doesnt actually do anything just an example, there will probably be something separate to control scores
    //    scores[0] =+ x;
    //    scores[1] =+ x;
    //    scores[2] =+ x;
    //    scores[3] =+ x;
    //}

    //public float getTimerStart()
    //{
    //    timerStartPoint = floorNum * floorNum; //not actually how we are going to calculate, just an example
    //    return timerStartPoint;
    //}

    public void setFinishTime(int playerIndex)
    {
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        string[] temp = timer.textDisplay.text.Split(' ');
        finishTimes[playerIndex] = float.Parse(temp[1]);
        Debug.Log("Player " + playerIndex + "'s time is " + finishTimes[playerIndex]);
    }

    public void nextLevel()
    {
        Debug.Log("NEXT LEVEL");
        complete[0] = false;
        complete[1] = false;
        complete[2] = false;
        complete[3] = false;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(0);
    }




}
