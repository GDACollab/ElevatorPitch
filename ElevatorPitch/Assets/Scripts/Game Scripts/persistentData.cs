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
    public int[] buttonMash = new int[4];
    //int floorNum;
    //int gamesPlayed;
    private AudioSource audioSource;
    public AudioClip calmElevatorMusic;
    public AudioClip[] fastMinigameMusic = new AudioClip[2];
    private int randomSong;    
    public int levelsPlayed = 0;

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);    
        //gamesPlayed = 0;
        //floorNum = 0;
        scores[0] = 0;
        scores[1] = 0;
        scores[2] = 0;
        scores[3] = 0;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        audioSource.Stop();
        if(scene.name == "quips" || scene.name == "Start")
        {
            audioSource.clip = calmElevatorMusic;
            audioSource.loop = true;
            audioSource.Play();
        } else if(scene.name == "SceneTransition") {
            //play other sound
        } else {
            int temp = Random.Range(0, fastMinigameMusic.Length - 1);
            while(randomSong == temp){
                temp = Random.Range(0, fastMinigameMusic.Length - 1); //make sure we dont play same song twice
            }
            randomSong = temp;
            audioSource.PlayOneShot(fastMinigameMusic[randomSong]);
        }

    }
   
    //singleton pattern
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();        

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

    public void setFinishTime(int playerIndex) //Player index = 0: Blaze, 1: Gian, 2: Robyn, 3: Yeet
    {
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        string[] temp = timer.textDisplay.text.Split(' ');
        finishTimes[playerIndex] = float.Parse(temp[1]);
        Debug.Log("Player " + playerIndex + "'s time is " + finishTimes[playerIndex]);
    }

    public void nextLevel()
    {
        levelsPlayed++;
        Debug.Log("NEXT LEVEL");
        complete[0] = false;
        complete[1] = false;
        complete[2] = false;
        complete[3] = false;
        SceneManager.LoadScene(1); //Loading transition scene where it decides the next level
    }
}
