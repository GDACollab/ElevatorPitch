﻿using System;
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
    public GameObject pawn;
    public AudioClip buttonPress;
    AudioSource source;
    persistentData pd;

    bool paused = false;
    int index;

    private void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        index = gameObject.GetComponent<PlayerInput>().playerIndex;
        source = gameObject.GetComponent<AudioSource>();
        pd = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>();
    }

    //Pause function
    void OnPause()
    {
        if(Time.timeScale > 0 && !paused)
        {
            PauseMenu.playerPause = index + 1; //Tell pause menu which player paused
            Time.timeScale = 0f;
            paused = true;
            PauseMenu.justPaused = true;
        }
        else if(paused) //Only the player who paused can unpause
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
        //Debug.Log(move);
    }
    void OnUpButton()
    {
        //Debug.Log("North Button Pressed");
    }
    void OnDownButton()
    {
        if(pd.ending)
        {
            pd.playAgain();
        }
        if(paused)
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
                pawn.transform.localPosition = pawn.transform.localPosition +=
                new Vector3(move.x * movementSpeed * Time.deltaTime, move.y * movementSpeed * Time.deltaTime);
                Rotation();
            }
        }
    }
    void Rotation()
    {
        float angle = Mathf.Atan2(move.y, move.x) * 180/Mathf.PI;
        //Debug.Log(angle);
        pawn.transform.rotation = Quaternion.Slerp(pawn.transform.rotation, Quaternion.Euler(0, 0, angle), interpolation * Time.deltaTime);
    }
}

