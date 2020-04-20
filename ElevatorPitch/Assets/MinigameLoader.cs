using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Written by Santiago Ponce
//saponce@ucsc.edu

public class MinigameLoader : MonoBehaviour
{
    public float maxTime;
    public Text textDisplay = null;
    //string instructions = "";
    public int firstMinigame = 1;
    public GameObject[] text = new GameObject[4];
    public GameObject[] playerSprites = new GameObject[4];
    public Text[] playerSpeechBubbles = new Text[4];
    public string[] characterNames = new string[4];
    persistentData persistentData;
    int firstPlace;
    int lastPlace;
    [Tooltip("Character shake during quips: Increase # to Decrease Shake")]
    public int shakeModifier = 8;

    // Start is called before the first frame update
    void Start()
    {

        

        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
        //If we find persistentData, use it to determine quips
        if (persistentData)
        {
            Debug.Log("Found Pers Data");
            int maxScore = Mathf.Max(persistentData.scores); //Get max score
            int minScore = Mathf.Min(persistentData.scores); //Get min score
            firstPlace = System.Array.IndexOf(persistentData.scores, maxScore); //first place index
            lastPlace = System.Array.IndexOf(persistentData.scores, minScore); //last place index

            string[] winningQuips = {
            "Wow " + characterNames[lastPlace] + " you suck at this!",
            "YEET!",
            "Git Gud " + characterNames[lastPlace],
            "Not to brag, but I'm the best.",
            "Do you need some help " + characterNames[lastPlace] + "?",
            "It's Yeet or be Yeeted, and I'm the Yeeter.",
            "I'm only using 3% of my power.",
            "MUDA MUDA MUDA",
        };

            string[] losingQuips = {
            "Don't be mean, " + characterNames[firstPlace] + "!",
            "Just you wait " + characterNames[firstPlace] + "!",
            "Next round is mine!",
            "Don't get cocky " + characterNames[firstPlace] + ", I'll catch up to you.",
            "Slow and steady wins the race!",
            "I'll have to go even further beyond",
            "Fiddlesticks!",
            ":'(",
        };

            //Show first place sprite and update speech
            playerSprites[firstPlace].SetActive(true);
            playerSpeechBubbles[firstPlace].gameObject.SetActive(true);
            int index = Random.Range(0, winningQuips.Length);
            playerSpeechBubbles[firstPlace].text = winningQuips[index];

            //Show last place sprite and update speech
            playerSprites[lastPlace].SetActive(true);
            playerSpeechBubbles[lastPlace].gameObject.SetActive(true);
            index = Random.Range(0, losingQuips.Length);
            playerSpeechBubbles[lastPlace].text = losingQuips[index];
        }
        else
        {
            Debug.Log("Did not find Pers Data, make sure you don't start from the transition scene");
        }
        

        /* Chooses next game with a random number
         * Starts at 1 because 0 is the transition scene.
         * Important: If more non-minigame scenes are added, make sure to adjust the firstMinigame variable 
         * to make sure they are not selected by accident
         * */
        //Debug.Log(SceneManager.sceneCountInBuildSettings);
        int nextGame = Random.Range(firstMinigame, SceneManager.sceneCountInBuildSettings);
        foreach(var x in text)
        {
            if(x != null) x.SetActive(false);
        }
        //Add more instructions when adding new minigames
        int cubicleRush = firstMinigame;
        int survive = 2;
        if(nextGame == cubicleRush + 0) //Cubicle rush
        {
            //instructions = "Get to your cubicle!";
            text[nextGame].SetActive(true);

        } else if (nextGame == survive)
        {
            //instructions = "SURVIVE!";
            text[nextGame].SetActive(true);
        } else if (nextGame == 3)
        {
            //instructions = "DODGE!";
            text[nextGame].SetActive(true);
        }
        else //Unknown minigame
        {
            //instructions = "Get ready!";
        }

        StartCoroutine(waitTime(nextGame));
    }

    private void Update()
    {
        //Apply shake to first place sprite
        Vector2 originalPositionFirstPlace = playerSprites[firstPlace].transform.position;
        playerSprites[firstPlace].transform.position = originalPositionFirstPlace + Random.insideUnitCircle/shakeModifier;

        //Apply shake to last place sprite
        Vector2 originalPositionLastPlace = playerSprites[lastPlace].transform.position;
        playerSprites[lastPlace].transform.position = originalPositionLastPlace + Random.insideUnitCircle/shakeModifier;

    }

    IEnumerator waitTime(int scene)
    {
        //Debug.Log(scene);
        yield return new WaitForSeconds(0.3f);
        //textDisplay.text = instructions; //Display instructions
        bool toggle = true;
        while (maxTime> 0)
        {
            yield return new WaitForSeconds(0.3f); //Wait a few seconds
            if (toggle)
            {
                text[scene].SetActive(false);
                toggle = false;
            } else
            {
                text[scene].SetActive(true);
                toggle = true;
            }
            maxTime -= 0.3f;
        }
        //Debug.Log("Loading next scene");
        SceneManager.LoadScene(scene); //Load scene
    }
}
