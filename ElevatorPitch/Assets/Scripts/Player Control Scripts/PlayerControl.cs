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
    //private GameObject prefabController;
    private int gameMode;
    public GameObject pawn;

    bool paused = false;
    int index;

    Vector3 grabPosition;
    GameObject blazeArm;
    GameObject gianArm;
    GameObject robynArm;
    GameObject yeetArm;

    private void Start()
    {
        persistantData = GameObject.FindGameObjectWithTag("persData");
        sr = gameObject.GetComponent<SpriteRenderer>();
        index = gameObject.GetComponent<PlayerInput>().playerIndex;
        gameMode = gameObject.GetComponent<CharacterPrefabController>().getGameMode();
        Debug.Log("Gotten gameMode: " + gameMode);
        if (gameMode == 2)
        {
            blazeArm = GameObject.FindGameObjectWithTag("blazeCoffeeArm");
            gianArm = GameObject.FindGameObjectWithTag("gianCoffeeArm");
            robynArm = GameObject.FindGameObjectWithTag("robynCoffeeArm");
            yeetArm = GameObject.FindGameObjectWithTag("yeetCoffeeArm");
        }

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

    void OnMovement(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    void OnUpButton()
    {
        Debug.Log("North Button Pressed");
    }

    void OnDownButton()
    {
        Debug.Log("South Button Pressed");
        if (paused)
        {
            Debug.Log("South Button Pressed");
            if (PauseMenu.cursorPosition == 0)
            {
                Time.timeScale = 1f;
                paused = false;
            }
            else if (PauseMenu.cursorPosition == 1)
            {
                //Mute, could update with full volume control later
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
            }
            else if (PauseMenu.cursorPosition == 2)
            {
                Debug.Log("Exit");
                Application.Quit(); //Maybe replace this with going to the start screen?
            }
        }
        else if (gameMode == 2)
        {
            persistantData.GetComponent<persistentData>().buttonMash[index]++;
        }
    }

    void OnLeftButton()
    {
        Debug.Log("Left Button Pressed");

    }

    void OnRightButton()
    {
        Debug.Log("Right Button Pressed. Gamemode is " + gameMode);
        if (gameMode == 2)
        {
            grabPosition = new Vector3(-1, -1, 0);
            switch (index)
            {
                case 0:
                    //blazeArm.transform.position = Vector2.Lerp(blazeArm.transform.position, grabPosition, Time.time);
                    blazeArm.transform.position = Vector2.MoveTowards(blazeArm.transform.position, grabPosition, 2);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            //pawn.transform.localPosition += new Vector3(2, 2, 2);
            //pawn.transform.localPosition = Vector2.MoveTowards(pawn.transform.localPosition, new Vector3(-1, -1, 0), 1);
            //while (pawn.transform.localPosition != grabPosition)
            //{
            //    pawn.transform.localPosition = Vector2.MoveTowards(pawn.transform.localPosition, grabPosition, .01f);
            //}


            //pawn.transform.localPosition = Vector2.Lerp(pawn.transform.localPosition, grabPosition, Time.time);
        }
    }

    void FixedUpdate()
    {
        if (pawn != null)
        {
            if (move != Vector2.zero)
            {
                if (gameMode != 2) //If in gameMode 2, don't allow movement
                {
                    pawn.transform.localPosition = pawn.transform.localPosition += new Vector3(move.x * movementSpeed * Time.deltaTime, move.y * movementSpeed * Time.deltaTime);
                    Rotation();
                }
                else
                {
                    //pawn.transform.localPosition = Vector2.Lerp(pawn.transform.localPosition, grabPosition, Time.time/20);
                    grabPosition = new Vector3(-1, -1, 0);
                    //blazeArm.transform.position += Vector3.MoveTowards(blazeArm.transform.position, grabPosition, 2 * Time.deltaTime);
                }

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
}

