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
                "Green is the color of Envy, Giang. It suits you.",
                "You know what's green? Plants. You know what they're good at? Staying in their place.",
                "DON'T TELL ME TO CALM DOWN. I'M CALM, I'M WINNING.",
                "Hah! First place! Screw everyone who ever doubted me! I don't care that you've supported me the whole way Giang, screw you anyways.",
                "Try better next time you head of cabbage.",
                "This is going in my cringe compilation.",
                };
                int index = Random.Range(0, blazeToGianQuips.Length);
                quips[0] = blazeToGianQuips[index];
            }
            else if (losing == 2) //and Robyn in last
            {
                string[] blazeToRobynQuips = {
                "Robin is a bird right? Even if you could fly, you'd still be beneath me.",
                "I didn't know robins were spineless birds.",
                "Are you embarrassed, or just sticking to your color scheme?",
                "For a name like robin you don't really have a bird's grace.",
                "You look red. Haha gottem.",
                "Looks like you got Robbedin. Haha Gottem.",
                };
                int index = Random.Range(0, blazeToRobynQuips.Length);
                quips[0] = blazeToRobynQuips[index];
            }
            else if (losing == 3) //and Yeet in last
            {
                string[] blazeToYeetQuips = {
                "Oh, are you shaking because of how cool I am?",
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
                "Cheer up Blake, you'll get 'em next... well, uh, you'll get 'em eventually.",
                "I'm sure you're just 'graciously allowing me to be in the lead', Blake. I appreciate that.",
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
                "Caffeine isn't very good for you...",
                "Have you tried doing yoga? It can help slow you down.",
                "Ya-Yi, you should look before you leap into a flaming chair next time... I worry for you.",
                "Hey Ya-Yi, take some deep breaths for me okay? I can't tell if you're hyperventilating or hypervibrating.",
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
                "Why are you trying so hard? Last place suits you.",
                "Blake, maybe you should keep your eyes on the prize, or else someone else might take it from you.",
                "Hey Blake, maybe you'd be winning more if you weren't being so competitive.",
                "Blake, you are trying, right? Well, I guess it's in character to keep tripping at the finish line.",
                "You seem burnt burnt to a crisp crsip...",
                "Hey don't be extinguished... I'm sorry... I'm sorry...",
                "Competition is scary, good thing I don't have any.",
                };
                int index = Random.Range(0, RobynToBlazeQuips.Length);
                quips[0] = RobynToBlazeQuips[index];
            }
            else if (losing == 1) //and Gian in last
            {
                string[] RobynToGianQuips = {
                "Red and green are opposites. So it makes sense so you were meant to be last.",
                "Giang, if you keep dozing off like that I'll be the CEO in no time.",
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
                "Maybe it was your shaky hands but taking the win from you was too easy.",
                "Maybe... if you yeet yeeted yourself a bit you'd do a bit better?",
                "Are you alright? Or are just shaking again? I'm sorry sorry... I'm getting worried a bit....",
                "I don't like conflict but I don't think I'd count this.",
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
                "Cool as ice and just as slow",
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
                "Robins a bird right? You got broken wings? Where's your speed?",
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
                "You got lucky, next one is mine!",
                "That's an epic win! This can't go in my cringle compilation",
                "You're so soft, yet so brave, yet so epic.",
                };
                int index = Random.Range(0, blazeToGianQuips.Length);
                quips[1] = blazeToGianQuips[index];
            }
            else if (winning == 2) //and Robyn in first
            {
                string[] blazeToRobynQuips = {
                "I don't wanna talk about it...",
                "Yeah that's pretty good I guess, kinda feel robbed but whatever.",
                "Okay cool, caught you red handed in the act or something cool whatever.",
                };
                int index = Random.Range(0, blazeToRobynQuips.Length);
                quips[1] = blazeToRobynQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] blazeToYeetQuips = {
                "You just won because you drank all that Bang!",
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
                "Wow, you're doing so well!",
                "I'm so proud of you! It's like a seeing a flame light up!",
                "You're doing great and you didn't violate any regulations!",
                };
                int index = Random.Range(0, gianToBlazeQuips.Length);
                quips[1] = gianToBlazeQuips[index];
            }
            else if (winning == 2) //and Robyn in first
            {
                string[] gianToRobynQuips = {
                "I admire your resilience!",
                "Wow! You're doing so well I didn't notice it's almost like you stole it!",
                "I see that red on your cheeks! You're doing so great!",
                };
                int index = Random.Range(0, gianToRobynQuips.Length);
                quips[1] = gianToRobynQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] gianToYeetQuips = {
                "I wish I was as fast as you!",
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
                "Um...good job. I wish I could be that cool...",
                "Blake's smoking. Not in a bad bad way either!",
                "Wow wow! I can't believe it Blake you're on fire!... Not like for real real though...",
                };
                int index = Random.Range(0, RobynToBlazeQuips.Length);
                quips[1] = RobynToBlazeQuips[index];
            }
            else if (winning == 1) //and Gian in first
            {
                string[] RobynToGianQuips = {
                "Oh well. At least you aren't the type to rub it in.",
                "You're doing more more than the usual as always!",
                "Giang you're always so reliable reliable!",
                };
                int index = Random.Range(0, RobynToGianQuips.Length);
                quips[1] = RobynToGianQuips[index];
            }
            else if (winning == 3) //and Yeet in first
            {
                string[] RobynToYeetQuips = {
                "Wow! Look at you go!",
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
                "Break a leg, actually break both of em.",
                };
                int index = Random.Range(0, YeetToBlazeQuips.Length);
                quips[1] = YeetToBlazeQuips[index];
            }
            else if (winning == 1) //and Gian in first
            {
                string[] YeetToGianQuips = {
                "Giang you're doin' pretty sweet like Valley Dew™️!",
                "I'm low on caffeine, carry mee I might actually make you faster!",
                "Caffination triggers the imagination!",
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
