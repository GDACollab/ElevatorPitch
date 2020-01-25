using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalComplete : MonoBehaviour
{
    [SerializeField]
    private bool isGoalComplete = false;
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

}
