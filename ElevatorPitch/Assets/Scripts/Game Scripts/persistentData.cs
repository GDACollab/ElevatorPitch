using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class persistentData : MonoBehaviour
{
    //initializing variables
    public static persistentData main;
    int[] scores = new int[4];
    int floorNum;
    float timerStartPoint;
    private AudioSource audioSource;

    void Start()
    {
        
        floorNum = 0;
        scores[0] = 0;
        scores[1] = 0;
        scores[2] = 0;
        scores[3] = 0;

    }

   
    //singleton pattern
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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


    public void nextLevel()
    {
        Debug.Log("NEXT LEVEL");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }




}
