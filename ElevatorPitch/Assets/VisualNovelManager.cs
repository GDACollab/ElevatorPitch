using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Written by Jacob Compton
//jrcompto@ucsc.edu

public class VisualNovelManager : MonoBehaviour
{

    public GameObject[] leftSprites = new GameObject[4];
    public GameObject[] rightSprites = new GameObject[4];
    private Image leftCharacterNameBox;
    private Image rightCharacterNameBox;
    public string[] characterNames = new string[4];
    TextMeshProUGUI leftVnNameText;
    TextMeshProUGUI rightVnNameText;
    TextMeshProUGUI vnCharacterSpeechText;
    persistentData persistentData;
    int firstPlace;
    int lastPlace;

    // Start is called before the first frame update
    void Start()
    {

        leftVnNameText = GameObject.FindGameObjectWithTag("leftVnNameText").GetComponent<TextMeshProUGUI>(); //Get name text box
        rightVnNameText = GameObject.FindGameObjectWithTag("rightVnNameText").GetComponent<TextMeshProUGUI>(); //Get name text box
        vnCharacterSpeechText = GameObject.FindGameObjectWithTag("vnCharacterSpeechText").GetComponent<TextMeshProUGUI>(); //Get name text box
        leftCharacterNameBox = GameObject.FindGameObjectWithTag("leftCharacterNameBox").GetComponent<Image>(); //Get name text box;
        rightCharacterNameBox = GameObject.FindGameObjectWithTag("rightCharacterNameBox").GetComponent<Image>(); //Get name text box;
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData

        leftCharacterNameBox.enabled = true;
        leftVnNameText.enabled = true;
        rightCharacterNameBox.enabled = false;
        rightVnNameText.enabled = false;

        //If we find persistentData, use it to determine quips
        if (persistentData)
        {
            Debug.Log("Found Pers Data");
            int maxScore = Mathf.Max(persistentData.scores); //Get max score
            int minScore = Mathf.Min(persistentData.scores); //Get min score
            firstPlace = System.Array.IndexOf(persistentData.scores, maxScore); //first place index
            lastPlace = System.Array.IndexOf(persistentData.scores, minScore); //last place index

            string[] quips = GetQuips(firstPlace, lastPlace);

            //Show first place sprite and update speech
            leftSprites[firstPlace].SetActive(true);
            leftVnNameText.text = characterNames[firstPlace];
            vnCharacterSpeechText.text = quips[0];

            //Show last place sprite and update speech
            rightSprites[lastPlace].SetActive(true);

            StartCoroutine(waitTime(characterNames, quips));
        }
        else
        {
            Debug.Log("Did not find Pers Data, make sure you don't start from the transition scene");
        }
    }

    IEnumerator waitTime(string[] names, string[] quips)
    {
        yield return new WaitForSeconds(5);
        leftCharacterNameBox.enabled = false;
        leftVnNameText.enabled = false;
        rightCharacterNameBox.enabled = true;
        rightVnNameText.enabled = true;
        rightVnNameText.text = characterNames[lastPlace];
        vnCharacterSpeechText.text = quips[1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    private string[] GetQuips(int winning, int losing)
    {
        //Quips, where position 0 is the winning quip and 1 is the losing quip
        string[] quips = new string[2];

        //Check who is winning and decide quip off that
        if (winning == 0) //Blaze in 1st
        {
            if (losing == 1) //and Gian in last
            {
                string[] blazeToGianQuips = {
                "Try better next time you head of cabbage.",
                "This is going in my cringe compilation.",
                };
                int index = Random.Range(0, blazeToGianQuips.Length);
                quips[0] = blazeToGianQuips[index];
            }
            else if (losing == 2) //and Robyn in last
            {
                string[] blazeToRobynQuips = {
                "You look red. Haha gottem.",
                "Looks like you got Robbedin. Haha Gottem.",
                };
                int index = Random.Range(0, blazeToRobynQuips.Length);
                quips[0] = blazeToRobynQuips[index];
            }
            else if (losing == 3) //and Yeet in last
            {
                string[] blazeToYeetQuips = {
                "Get yoted.",
                "You shake a lot, how about you... don't shake.",
                };
                int index = Random.Range(0, blazeToYeetQuips.Length);
                quips[0] = blazeToYeetQuips[index];
            }
        }
        else if (winning == 1) //Gian in 1st
        {
            if (losing == 0) //and Blaze in last
            {
                string[] gianToBlazeQuips = {
                "Are you ok Blake? Do you wanna see pictures of my dogs? Might cheer you up...",
                "Can I see your cringe compilation? It makes me happy :).",
                };
                int index = Random.Range(0, gianToBlazeQuips.Length);
                quips[0] = gianToBlazeQuips[index];
            }
            else if (losing == 2) //and Robyn in last
            {
                string[] gianToRobynQuips = {
                "Robin is a bird right? I like birds they're cute...",
                "It sucks when stuff gets robbed from you.",
                };
                int index = Random.Range(0, gianToRobynQuips.Length);
                quips[0] = gianToRobynQuips[index];
            }
            else if (losing == 3) //and Yeet in last
            {
                string[] gianToYeetQuips = {
                "Have you tried doing yoga? It can help slow you down.",
                "Hey Ya-Yi, take some deep breaths for me okay? I can't tell if you're hyperventilating or hypervibrating.",
                };
                int index = Random.Range(0, gianToYeetQuips.Length);
                quips[0] = gianToYeetQuips[index];
            }
        }
        else if (winning == 2) //Robyn in 1st
        {
            if (losing == 0) //and Blaze in last
            {
                string[] RobynToBlazeQuips = {
                "You seem burnt burnt to a crisp crsip...",
                "Hey don't be extinguished... I'm sorry... I'm sorry...",
                };
                int index = Random.Range(0, RobynToBlazeQuips.Length);
                quips[0] = RobynToBlazeQuips[index];
            }
            else if (losing == 1) //and Gian in last
            {
                string[] RobynToGianQuips = {
                "Giang, if you keep dozing off like that I'll be the CEO... Oh god oh god...",
                "Your dogs are so cute cute... they're almost a bit distracting... a bit...",
                "I was gonna steal first place but you just gave it to me",
                };
                int index = Random.Range(0, RobynToGianQuips.Length);
                quips[0] = RobynToGianQuips[index];
            }
            else if (losing == 3) //and Yeet in last
            {
                string[] RobynToYeetQuips = {
                "Maybe... if you yeet yeeted yourself a bit you'd do a bit better?",
                "Are you alright? Or are just shaking again? I'm sorry sorry... I'm getting worried a bit....",
                };
                int index = Random.Range(0, RobynToYeetQuips.Length);
                quips[0] = RobynToYeetQuips[index];
            }
        }
        else if (winning == 3) //Yeet in 1st
        {
            if (losing == 0) //and Blaze in last
            {
                string[] YeetToBlazeQuips = {
                "Ayy dab epic, lookin' pretty cool here. B)",
                "I'm LIT.",
                };
                int index = Random.Range(0, YeetToBlazeQuips.Length);
                quips[0] = YeetToBlazeQuips[index];
            }
            else if (losing == 1) //and Gian in last
            {
                string[] YeetToGianQuips = {
                "Giang! You're the tank! You're supposed to be in front!",
                "Never give up bud! You're pretty epic you'll vibrate like me one day!",
                };
                int index = Random.Range(0, YeetToGianQuips.Length);
                quips[0] = YeetToGianQuips[index];
            }
            else if (losing == 2) //and Robyn in last
            {
                string[] YeetToRobynQuips = {
                "Oh jeez, now I'm turning red!",
                "Guess I stole the show this time!",
                };
                int index = Random.Range(0, YeetToRobynQuips.Length);
                quips[0] = YeetToRobynQuips[index];
            }
        }

        //Check who is losing and decide quip off that
        if (losing == 0) //Blaze in last
        {
            if (winning == 1) //and Gian in first
            {
                string[] blazeToGianQuips = {
                "That's an epic win! This can't go in my cringle compilation",
                "You're so soft, yet so brave, yet so epic.",
                };
                int index = Random.Range(0, blazeToGianQuips.Length);
                quips[1] = blazeToGianQuips[index];
            }
            else if (winning == 2) //and Robyn in first
            {
                string[] blazeToRobynQuips = {
                "Yeah that's pretty good I guess, kinda feel robbed but whatever.",
                "Okay cool, caught you red handed in the act or something cool whatever.",
                };
                int index = Random.Range(0, blazeToRobynQuips.Length);
                quips[1] = blazeToRobynQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] blazeToYeetQuips = {
                "I got yeeted, but nice... I guess.",
                "You really just vibrated to the top huh?",
                };
                int index = Random.Range(0, blazeToYeetQuips.Length);
                quips[1] = blazeToYeetQuips[index];
            }
        }
        else if (losing == 1) //Gian in last
        {
            if (winning == 0) //and Blaze in first
            {
                string[] gianToBlazeQuips = {
                "I'm so proud of you! It's like a seeing a flame light up!",
                "You're doing great and you didn't violate any regulations!",
                };
                int index = Random.Range(0, gianToBlazeQuips.Length);
                quips[1] = gianToBlazeQuips[index];
            }
            else if (winning == 2) //and Robyn in first
            {
                string[] gianToRobynQuips = {
                "Wow! You're doing so well I didn't notice it's almost like you stole it!",
                "I see that red on your cheeks! You're doing so great!",
                };
                int index = Random.Range(0, gianToRobynQuips.Length);
                quips[1] = gianToRobynQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] gianToYeetQuips = {
                "Epic! I wish I could vibrate just like you!",
                "Yeet! I'm so proud of you! Your energy is yeet!",
                };
                int index = Random.Range(0, gianToYeetQuips.Length);
                quips[1] = gianToYeetQuips[index];
            }
        }
        else if (losing == 2) //Robyn in last
        {
            if (winning == 0) //and Blaze in first
            {
                string[] RobynToBlazeQuips = {
                "Blake's smoking. Not in a bad bad way either!",
                "Wow wow! I can't believe it Blake you're on fire!... Not like for real real though...",
                };
                int index = Random.Range(0, RobynToBlazeQuips.Length);
                quips[1] = RobynToBlazeQuips[index];
            }
            else if (winning == 1) //and Gian in first
            {
                string[] RobynToGianQuips = {
                "You're doing more more than the usual as always!",
                "Giang you're always so reliable reliable!",
                };
                int index = Random.Range(0, RobynToGianQuips.Length);
                quips[1] = RobynToGianQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] RobynToYeetQuips = {
                "If only you could yeet yeet me where you are right now!... Maybe not actually....",
                "Wow cool cool! You're making me shake too!",
                };
                int index = Random.Range(0, RobynToYeetQuips.Length);
                quips[1] = RobynToYeetQuips[index];
            }
        }
        else if (losing == 3) //Yeet in last
        {
            if (winning == 0) //and Blaze in first
            {
                string[] YeetToBlazeQuips = {
                "Blake you're like Blastin Baja™️!",
                "Yo you're pretty lit right now!",
                };
                int index = Random.Range(0, YeetToBlazeQuips.Length);
                quips[1] = YeetToBlazeQuips[index];
            }
            else if (winning == 1) //and Gian in first
            {
                string[] YeetToGianQuips = {
                "Giang you're doin' pretty sweet like Valley Dew™️!",
                "I'm low on caffeine, carry mee I might actually make you faster!",
                };
                int index = Random.Range(0, YeetToGianQuips.Length);
                quips[1] = YeetToGianQuips[index];
            }
            else if (winning == 2) //and Robyn in first
            {
                string[] YeetToRobynQuips = {
                "Robin is goin' off like Code Red™️!",
                "Stealin the spotlight! I Like it!",
                };
                int index = Random.Range(0, YeetToRobynQuips.Length);
                quips[1] = YeetToRobynQuips[index];
            }
        }
        return quips;
    }
}
