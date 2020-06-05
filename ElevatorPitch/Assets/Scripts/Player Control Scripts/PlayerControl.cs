using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [Range(0f, 10f)]
    public float interpolation;
    Vector2 move;
    public float movementSpeed;
    private SpriteRenderer sr;
    private GameObject persistantData;
    private CharacterPrefabController prefabController;
    private int gameMode;
    public GameObject pawn;
    public AudioClip buttonPress;
    AudioSource source;
    persistentData pd;
    PauseMenu pauseMenu;
    Ending endingScript;

    bool paused = false;
    int index;
    ParticleSystem blazeParticle;
    ParticleSystem giangParticle;
    ParticleSystem robynParticle;
    ParticleSystem yeetParticle;
    GameObject blazeArm;
    GameObject gianArm;
    GameObject robynArm;
    GameObject yeetArm;
    GameObject[] emailBars;

    private void Awake()
    {

        emailBars = null;
        if (gameMode == 2)
        {
            findCoffeeArms();
        } else if (gameMode == 3) {
            findEmailBars();
        }
        persistantData = GameObject.FindGameObjectWithTag("persData");
        pauseMenu = persistantData.GetComponent<PauseMenu>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        index = gameObject.GetComponent<PlayerInput>().playerIndex;
        source = gameObject.GetComponent<AudioSource>();

        pd = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>();
        endingScript = GameObject.FindGameObjectWithTag("EndingScript").GetComponent<Ending>();

        prefabController = gameObject.GetComponent<CharacterPrefabController>();
        gameMode = prefabController.getGameMode();



    }

    //Pause function
    void OnPause()
    {
        if (Time.timeScale > 0 && !paused)
        {
            PauseMenu.playerPause = index + 1; //Tell pause menu which player paused
            Time.timeScale = 0f;
            paused = true;
            PauseMenu.justPaused = true;
        }
        else if (paused) //Only the player who paused can unpause
        {
            Time.timeScale = 1f;
            paused = false;
        }
    }

    void OnLeftFlick()
    {
        if (paused)
        {
            PauseMenu.cursorPosition -= 1; //Move cursor left
            if (PauseMenu.cursorPosition < 0)
            {
                PauseMenu.cursorPosition = 0;
            }
        }
    }

    void OnRightFlick()
    {
        if (paused)
        {
            PauseMenu.cursorPosition += 1; //Move cursor right
            if (PauseMenu.cursorPosition > 2)
            {
                PauseMenu.cursorPosition = 2;
            }
        }
    }

    void OnUpFlick()
    {
        if (paused && PauseMenu.cursorPosition == 1)
        {
            //Increase volume

            if (AudioListener.volume < 1.0f)
            {
                AudioListener.volume += 0.1f;
                PauseMenu.muted = false;
            }
            pauseMenu.volumeText = "Volume: " + Mathf.RoundToInt(AudioListener.volume * 100.0f) + "%";
        }
    }

    void OnDownFlick()
    {
        if(paused && PauseMenu.cursorPosition == 1)
        {
            //Decrease volume

            if (AudioListener.volume > 0.0f)
            {
                AudioListener.volume -= 0.1f;
            }
            if(AudioListener.volume <= 0.0f)
            {
                PauseMenu.muted = true;
            }
            pauseMenu.volumeText = "Volume: " + Mathf.RoundToInt(AudioListener.volume * 100.0f) + "%";
        }
    }

    void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnDownButton()
    {
        if(emailBars == null){
            findEmailBars();
        }

        if(pd != null){ //If persistent data is present
            if(endingScript != null)
            {
                endingScript.progress++; //Skip dialogue
                endingScript.timer = 10f;
            }

            if (pd.ending)
            {
                pd.playAgain();
            }
        }


        Debug.Log("South Button Pressed. Gamemode: " + gameMode);
        if (paused)

        {
            //Debug.Log("South Button Pressed");
            source.PlayOneShot(buttonPress); //Play sound
            if (PauseMenu.cursorPosition == 0)
            {
                Time.timeScale = 1f;
                paused = false;
            }
            else if (PauseMenu.cursorPosition == 1)
            {
                //Mute, could update with full volume control later
                /*
                if (PauseMenu.muted)
                {
                    AudioListener.volume = 1.0f; //Might not work for all audio sources
                    PauseMenu.muted = false;
                }
                else
                {
                    AudioListener.volume = 0.0f;
                    PauseMenu.muted = true;
                }
                */
            }
            else if (PauseMenu.cursorPosition == 2)
            {
                Debug.Log("Exit");
                Application.Quit(); //Maybe replace this with going to the start screen?
            }
        }
        else if (gameMode == 2 && Time.timeScale > 0) //Coffee Game
        {
            switch (index) //0: Blaze, 1: Gian, 2: Robyn, 3: Yeet
            {
                case 0:
                    if (blazeArm.GetComponent<coffeeGrab>().GetGrabbedMug(index) == false && !(blazeArm.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("blakeCoffeeGrab")))
                    {
                        blazeArm.GetComponent<Animator>().SetTrigger("buttonPushed");
                    }
                    break;
                case 1:
                    if (gianArm.GetComponent<coffeeGrab>().GetGrabbedMug(index) == false && !(gianArm.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("gianCoffeeGrab")))
                    {
                        gianArm.GetComponent<Animator>().SetTrigger("buttonPushed");
                    }
                    break;
                case 2:
                    if (robynArm.GetComponent<coffeeGrab>().GetGrabbedMug(index) == false && !(robynArm.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("robynCoffeeGrab")))
                    {
                        robynArm.GetComponent<Animator>().SetTrigger("buttonPushed");
                    }
                    break;
                case 3:
                    if (yeetArm.GetComponent<coffeeGrab>().GetGrabbedMug(index) == false && !(yeetArm.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("yeetCoffeeGrab")))
                    {
                        yeetArm.GetComponent<Animator>().SetTrigger("buttonPushed");
                    }
                    break;
                default:
                    Debug.Log("Couldn't find trigger for arm animation");
                    break;
            }
        }

        else if(gameMode == 3 && Time.timeScale > 0)//Button Mash Game
        {

            switch(index){
                case 0:
                    if(blazeParticle.isPlaying){
                        blazeParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                    blazeParticle.Play(true);
                    break;
                case 1:
                    if(giangParticle.isPlaying){
                        giangParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                    giangParticle.Play(true);
                    break;
                case 2:
                    if(robynParticle.isPlaying){
                        robynParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                    robynParticle.Play(true);
                    break;
                case 3:
                    if(yeetParticle.isPlaying){
                        yeetParticle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    }
                    yeetParticle.Play(true);
                    break;
                default:
                    break;
            }
            persistantData.GetComponent<persistentData>().buttonMash[index]++;
            foreach(GameObject bar in emailBars) {
                bar.GetComponent<emailColorSwap>().switchColor();
            }
        }
    }

    void OnLeftButton()
    {
        //Debug.Log("Left Button Pressed");

    }

    void OnRightButton()
    {
        //Debug.Log("Right Button Pressed");
    }

    void FixedUpdate()
    {

        if (pawn != null)
        {
            if (move != Vector2.zero)
            {

                pawn.transform.localPosition = pawn.transform.localPosition += new Vector3(move.x * movementSpeed * Time.deltaTime, move.y * movementSpeed * Time.deltaTime);
                Rotation();
            }
            pawn.GetComponent<Animator>().SetFloat("xVel", Mathf.Abs(move.x));
            if(move.x < 0){
                pawn.GetComponent<SpriteRenderer>().flipX = true;
            } else {
                pawn.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(move.y, move.x) * 180 / Mathf.PI;
        //Debug.Log(angle);
        pawn.transform.rotation = Quaternion.Slerp(pawn.transform.rotation, Quaternion.Euler(0, 0, angle), interpolation * Time.deltaTime);
    }

    public void setGameMode(int mode)
    {
        gameMode = mode;
    }

    public void findCoffeeArms()
    {
        blazeArm = GameObject.FindGameObjectWithTag("blazeCoffeeArm");
        gianArm = GameObject.FindGameObjectWithTag("gianCoffeeArm");
        robynArm = GameObject.FindGameObjectWithTag("robynCoffeeArm");
        yeetArm = GameObject.FindGameObjectWithTag("yeetCoffeeArm");
    }

    public void findEmailBars()
    {
        switch(index){
            case 0:
                emailBars = GameObject.FindGameObjectsWithTag("blakeEmailBar");
                blazeParticle = GameObject.FindGameObjectWithTag("blazeParticle").GetComponent<ParticleSystem>();
                break;
            case 1:
                emailBars = GameObject.FindGameObjectsWithTag("giangEmailBar");
                giangParticle = GameObject.FindGameObjectWithTag("giangParticle").GetComponent<ParticleSystem>();
                break;
            case 2:
                emailBars = GameObject.FindGameObjectsWithTag("robynEmailBar");
                robynParticle = GameObject.FindGameObjectWithTag("robynParticle").GetComponent<ParticleSystem>();
                break;
            case 3:
                emailBars = GameObject.FindGameObjectsWithTag("yeetEmailBar");
                yeetParticle = GameObject.FindGameObjectWithTag("yeetParticle").GetComponent<ParticleSystem>();
                break;
            default:
                break;
        }

    }
}
