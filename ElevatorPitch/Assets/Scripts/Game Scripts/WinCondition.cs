using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [Tooltip("0: Reach goal; 1: Survive; 2: CoffeeGame")]
    public int gameModeTemplate;
    persistentData persistentData;

    private void Start()
    {
        persistentData = GameObject.FindGameObjectWithTag("persData").GetComponent<persistentData>(); //Get PersistentData
    }

    public void goalCompletionCheck(int gameMode)
    {
        List<float> times = new List<float>(persistentData.finishTimes);
        int points;
        if(persistentData.getPlayerCount() != 1)
        {
            points = persistentData.getPlayerCount() - 1;
        }
        else
        {
            points = 1;
        }
        Debug.Log("Player Count: " + persistentData.getPlayerCount());
        if(gameMode == 2) //CoffeeGame uses same scoring as gamemode 0, just needed to tell the difference
        {
            gameMode = 0;
        }
        switch (gameMode)
        {
            case 0: //Reach Goal
                Debug.Log("In goal gamemode");
                for(int itr = persistentData.getPlayerCount(); itr < 4; itr++)
                {
                    times[itr] = -100;
                }
                while (Mathf.Max(times.ToArray()) != -100)
                {
                    //Debug.Log("Times: " + times[0] + ", " + times[1] + ", " + times[2] + ", " + times[3]);
                    float max = Mathf.Max(times.ToArray()); //Get fastest time, using max because the timer counts down
                    int indexOfMax = times.IndexOf(max);
                    //Debug.Log("Fastest time: " + max + " at " + indexOfMax);
                    if (persistentData.complete[indexOfMax] == false) //Player didn't make it to goal
                    {
                        times[indexOfMax] -= 20; //Set time below 0 so people who finished get more points
                        persistentData.complete[indexOfMax] = true;
                        continue;
                    }
                    int count = 0;
                    for(int i = 0; i < persistentData.getPlayerCount(); i++) //Check for players w/ same time
                    {
                        if(max == times[i])
                        {
                            count++;
                        }
                    }
                    persistentData.scores[indexOfMax] += points; //Give points based on speed
                    if (count == 1) //If no same scores, reduce points for next person, otherwise give next person same points
                    {
                        points--;
                    }
                    times[indexOfMax] = -100;
                }
                printDebugScores();
                break;
            case 1: //Survive
                Debug.Log("In survive gamemode");
                for (int itr = persistentData.getPlayerCount(); itr < 4; itr++)
                {
                    times[itr] = -1;
                }
                while (true)
                {
                    float min = 100; //Min set to impossible value for checks
                    for(int j = 0; j < 4; j++) //Loop through times and find lowest one that isn't -1
                    {
                        if(times.ToArray()[j] < min && times.ToArray()[j] != -1)
                        {
                            min = times.ToArray()[j]; //Getting lowest time because that would mean they stayed alive longest
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
            case 2: 
                //
                break;
            case 3: 
                List<int> mash = new List<int>(persistentData.buttonMash);
                for(int itr = persistentData.getPlayerCount(); itr < 4; itr++)
                {
                    mash[itr] = -100;
                }
                while (Mathf.Max(mash.ToArray()) != -100)
                {
                    //Debug.Log("Times: " + times[0] + ", " + times[1] + ", " + times[2] + ", " + times[3]);
                    int max = Mathf.Max(mash.ToArray()); //Get fastest time, using max because the timer counts down
                    int indexOfMax = mash.IndexOf(max);
                    //Debug.Log("Fastest time: " + max + " at " + indexOfMax);
                    
                    int count = 0;
                    for(int i = 0; i < persistentData.getPlayerCount(); i++) //Check for players w/ same time
                    {
                        if(max == mash[i])
                        {
                            count++;
                        }
                    }
                    persistentData.scores[indexOfMax] += points; //Give points based on speed
                    if (count == 1) //If no same scores, reduce points for next person, otherwise give next person same points
                    {
                        points--;
                    }
                    mash[indexOfMax] = -100;
                }
                printDebugScores();
                break;

            default:
                //default template
                Debug.Log("Gave no points");
                break;
        }
        for (int j = 0; j < 4; j++)
        {
            persistentData.timeUpdated[j] = false;
        }
    }

    public void printDebugScores()
    {
        Debug.Log("Scores: ");
        for(int i = 0; i < 4; i++)
        {
            Debug.Log("Player " + i + "'s Score: " + persistentData.scores[i]);
        }
        Debug.Log("Times: ");
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("Player " + i + "'s Time: " + persistentData.finishTimes[i]);
        }
    }
}
