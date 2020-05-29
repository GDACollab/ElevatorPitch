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
    public bool[] timeUpdated = new bool[4];
    //int floorNum;
    //int gamesPlayed;
    private AudioSource audioSource;
    public AudioClip calmElevatorMusic;
    public AudioClip[] fastMinigameMusic = new AudioClip[2];
    private int randomSong;
    public int levelsPlayed = 0;
    public int currentFloor = 0; //Similar to levelsPlayed, but only keeps track of minigames.
    public int endingFloor = 10;
    public int lives = 4;
    int[] defaultValues = new int[4];
    public bool ending = false; //This value should always be false
    private int playerCount = 0;

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
        //finishTimes[0] = 0;
        //finishTimes[1] = 0;
        //finishTimes[2] = 0;
        //finishTimes[3] = 0;
        timeUpdated[0] = false;
        timeUpdated[1] = false;
        timeUpdated[2] = false;
        timeUpdated[3] = false;

        defaultValues[0] = levelsPlayed;
        defaultValues[1] = currentFloor;
        defaultValues[2] = endingFloor;
        defaultValues[3] = lives;
    }


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        buttonMash[0] = 0;
        buttonMash[1] = 0;
        buttonMash[2] = 0;
        buttonMash[3] = 0;
        audioSource.Stop();
        if(scene.name == "quips" || scene.name == "Start" || scene.name == "Ending")
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
        playerCount++;
    }

    public void setFinishTime(int playerIndex) //Player index = 0: Blaze, 1: Gian, 2: Robyn, 3: Yeet
    {
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        string[] temp = timer.textDisplay.text.Split(' ');
        finishTimes[playerIndex] = float.Parse(temp[1]);
        //Debug.Log("Player " + playerIndex + "'s time is " + finishTimes[playerIndex]);
    }

    public void setFinishTime(int playerIndex, float time) //Player index = 0: Blaze, 1: Gian, 2: Robyn, 3: Yeet. This one is used to set time to 0 if player didnt touch anything
    {
        Timer timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        string[] temp = timer.textDisplay.text.Split(' ');
        finishTimes[playerIndex] = 0;
        //Debug.Log("Player " + playerIndex + "'s time is " + finishTimes[playerIndex]);
    }

    public void nextLevel()
    {
        if(SceneManager.GetActiveScene().name != "quips") //Does not count quips as minigames
        {
            currentFloor++;
        }
        levelsPlayed++;

        Debug.Log("NEXT LEVEL");
        complete[0] = false;
        complete[1] = false;
        complete[2] = false;
        complete[3] = false;
        SceneManager.LoadScene(1); //Loading transition scene where it decides the next level
    }

    public void playAgain() //Reset all values to default and return to start
    {
        for(int i = 0; i < 4; i++) //Reset scores
        {
            scores[i] = 0;
        }

        levelsPlayed = defaultValues[0]; //Reset values
        currentFloor = defaultValues[1];
        endingFloor = defaultValues[2];
        lives = defaultValues[3];

        ending = false;

        SceneManager.LoadScene(0); //Load start screen
    }

    public int getPlayerCount()
    {
        return playerCount;
    }
}
