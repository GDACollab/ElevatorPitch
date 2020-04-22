using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalComplete : MonoBehaviour
{
    [SerializeField]
    private bool isGoalComplete = false;
    [SerializeField]
    private string goalTag;
    private PlayerInput playerInput;
    private playerSetup setup;
    public int playerIndex;
    persistentData perisistentData;
    public AudioClip collide1;
    SoundManager playerAudio;
    private void Start()
    {
        playerAudio = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        playerInput = GetComponent<PlayerInput>();
        setup = GetComponent<playerSetup>();
        playerIndex = setup.controllerIndex;
        goalTag = "goal " + playerIndex;
        perisistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>();
        //Debug.Log(playerIndex);
    }
    public bool IsGoalComplete
    {
        get
        {
            return isGoalComplete;
        }
        set
        {
            isGoalComplete = value;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider);
        //Debug.Log(collision.transform.tag + " == " + (goalTag + " " + playerIndex.ToString()));

        if(collision.transform.CompareTag(goalTag))
        {
            IsGoalComplete = true;
            Debug.Log("goal complete");
            perisistentData.setFinishTime(playerIndex);
            perisistentData.complete[playerIndex] = true;
            //do something with persistant data;
            Destroy(gameObject);
        }
        if(collision.transform.tag == "enemy")
        {   
            isGoalComplete = false;
            Debug.Log("Hit by enemy");
            perisistentData.complete[playerIndex] = false;
            perisistentData.setFinishTime(playerIndex);
            playerAudio.playSound(collide1);
            //playerAudio.PlayOneShot(collide1);
            Destroy(gameObject);
        }
    }

}
