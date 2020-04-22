using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualNovelManager : MonoBehaviour
{

    public GameObject[] leftSprites = new GameObject[4];
    public GameObject[] rightSprites = new GameObject[4];
    public string[] characterNames = new string[4];
    TextMeshProUGUI vnNameText;
    TextMeshProUGUI vnCharacterSpeechText;
    persistentData persistentData;
    int firstPlace;
    int lastPlace;


    // Start is called before the first frame update
    void Start()
    {

        vnNameText = GameObject.FindGameObjectWithTag("vnNameText").GetComponent<TextMeshProUGUI>(); //Get name text box
        vnCharacterSpeechText = GameObject.FindGameObjectWithTag("vnCharacterSpeechText").GetComponent<TextMeshProUGUI>(); //Get name text box

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
            leftSprites[firstPlace].SetActive(true);
            int index = Random.Range(0, winningQuips.Length);
            Debug.Log(vnNameText);
            vnNameText.text = characterNames[firstPlace];
            vnCharacterSpeechText.text = winningQuips[index];

            //Show last place sprite and update speech
            rightSprites[lastPlace].SetActive(true);
            //index = Random.Range(0, losingQuips.Length);
            //vnCharacterSpeechText.text = losingQuips[index];
        }
        else
        {
            Debug.Log("Did not find Pers Data, make sure you don't start from the transition scene");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
