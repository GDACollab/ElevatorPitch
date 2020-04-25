using System.Collections;
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
                    
                    float max = Mathf.Max(times.ToArray()); //Get fastest time, using max because the timer counts down
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
                break;
            case 1: //Survive
                while (true)
                {
                    float min = 100; //Min set to impossible value for checks
                    for(int j = 0; j < 4; j++) //Loop through times and find lowest one that isn't -1
                    {
                        if(times.ToArray()[j] < min && times.ToArray()[j] != -1)
                        {
                            min = times.ToArray()[j];
                        }
                    }
                    if(min == 100) //If all values are -1, then min will stay 100, so end because all times are accounted for
                    {
                        printDebugScores();
                        break;
                    }
                    int count = 0; //Count for checking if people have the same finish times
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
                    times[times.IndexOf(min)] = -1; //Set this person's time to -1, signifying that they've been checked off
                }
                break;
            default:
                //default template
                Debug.Log("Gave no points");
                break;
        }
    }

    public void printDebugScores()
    {
        Debug.Log("Scores: ");
        for(int i = 0; i < 4; i++)
        {
            Debug.Log("Player " + i + "'s Score: " + persistentData.scores[i]);
        }
    }
}
