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
    persistentData persistentData;
    public AudioClip collide1;
    SoundManager playerAudio;

    public bool paused = false;

    private void Start()
    {
        playerAudio = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        playerInput = GetComponent<PlayerInput>();
        setup = GetComponent<playerSetup>();
        playerIndex = setup.controllerIndex;
        goalTag = "goal " + playerIndex;
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>();
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
            persistentData.setFinishTime(playerIndex);
            persistentData.complete[playerIndex] = true;
            persistentData.timeUpdated[playerIndex] = true;
            //do something with persistant data;
            Destroy(gameObject);
        }
        if(collision.transform.tag == "enemy")
        {   
            isGoalComplete = false;
            Debug.Log("Hit by enemy");
            persistentData.complete[playerIndex] = false;
            persistentData.setFinishTime(playerIndex);
            persistentData.timeUpdated[playerIndex] = true;
            playerAudio.playSound(collide1);
            //playerAudio.PlayOneShot(collide1);
            Destroy(gameObject);
        }
    }
}
