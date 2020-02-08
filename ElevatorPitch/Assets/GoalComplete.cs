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
    int playerIndex;
    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerIndex = playerInput.playerIndex;
        goalTag = "goal " + playerIndex;
        
        Debug.Log(playerIndex);
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
        Debug.Log(collision.transform.tag + " == " + (goalTag + " " + playerIndex.ToString()));

        if(collision.transform.CompareTag(goalTag))
        {
            IsGoalComplete = true;
            Debug.Log("goal complete");
            //do something with persistant data;
            Destroy(gameObject);
        }
        if(collision.transform.tag == "enemy")
        {
            
            isGoalComplete = false;
            Destroy(gameObject);
        }
    }

}
