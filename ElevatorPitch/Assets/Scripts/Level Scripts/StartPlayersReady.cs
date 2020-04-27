using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayersReady : MonoBehaviour
{
    GameObject Timer;
    private void Start()
    {
        Timer = GameObject.FindGameObjectWithTag("Timer");
    }


    private int playerCount = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerCount++;
        Debug.Log("TRIGGER :" + playerCount);
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerCount--;
    }

    private void Update()
    {
        if (playerCount == 2)
        {
            Debug.Log("CALLING DOTRANSITION");
            Timer.GetComponent<Timer>().doTransition();
            playerCount = -1;
        }
    }
}
