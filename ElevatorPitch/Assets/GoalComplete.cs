using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalComplete : MonoBehaviour
{
    [SerializeField]
    private bool isGoalComplete = false;
    [SerializeField]
    private string goalTag;

    private void Start()
    {
        goalTag = "goal 1";
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
        Debug.Log(collision.transform.tag);
        if(collision.transform.tag == goalTag)
        {
            IsGoalComplete = true;
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
