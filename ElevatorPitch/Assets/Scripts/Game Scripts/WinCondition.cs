﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Tooltip("0: Reach goal; 1: Survive")]
    public int gameModeTemplate;
    //public GoalComplete player1, player2, player3, player4;
    persistentData persistentData;

    private void Start()
    {
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
    }

    public void goalCompletionCheck(int gameMode)
    {
        List<float> times = new List<float>(persistentData.finishTimes);
        int points = 3;
        switch (gameMode)
        {
            case 0: //Reach Goal
                while (Mathf.Max(times.ToArray()) != -100)
                {
                    
                    float max = Mathf.Max(times.ToArray()); //Get fastest time
                    if (persistentData.complete[times.IndexOf(max)] == false && max < -20)
                    {
                        times[times.IndexOf(max)] = max - 20;
                        continue;
                    }
                    int count = 0;
                    for(int i = 0; i < 4; i++) //Check for players w/ same time
                    {
                        if(max == times[i])
                        {
                            count++;
                        }
                    }
                    persistentData.scores[times.IndexOf(max)] += points; //Give points based on speed
                    if (count == 1) //If no same scores, reduce points for next person, otherwise give next person same points
                    {
                        points--;
                    }
                    times[times.IndexOf(max)] = -100;
                }
                printDebugScores();
                return;
            case 1: //Survive
                while(Mathf.Max(times.ToArray()) != -1)
                {
                    float min = Mathf.Min(times.ToArray()); //Get biggest number(longest time)
                    int count = 0;
                    for (int i = 0; i < 4; i++) //Check for players w/ same score
                    {
                        if (min == times[i])
                        {
                            count++;
                        }
                    }
                    persistentData.scores[times.IndexOf(min)] += points; //Give points based on time alive
                    if (count == 1) //If no same scores, reduce points for next person, otherwise give next person same points
                    {
                        points--;
                    }
                    times[times.IndexOf(min)] = -1;
                }
                printDebugScores();
                return;
            default:
                //default template
                return;
        }
    }
    /*public bool winCompletionCheck()
    {
        int goalsCompleted = 0;
        if (player1.IsGoalComplete)
            goalsCompleted++;
        if (player2.IsGoalComplete)
            goalsCompleted++;
        if (player3.IsGoalComplete)
            goalsCompleted++;
        if (player4.IsGoalComplete)
            goalsCompleted++;
        if (goalsCompleted > 2)
        {
            return true;
        }
        return false;
    }*/

    public void printDebugScores()
    {
        Debug.Log("Scores: ");
        for(int i = 0; i < 4; i++)
        {
            Debug.Log("Player " + i + "'s Score: " + persistentData.scores[i]);
        }
    }

    /*public void template0()
    {
        ///This is where we determine which players have completed the goal for the first game template
    }*/
}
