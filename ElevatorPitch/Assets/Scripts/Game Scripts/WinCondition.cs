using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public int gameModeTemplate;
    public GoalComplete player1, player2, player3, player4;
    

    public void goalCompletionCheck(int gameMode)
    {
        switch (gameMode)
        {
            case 0:
                //game template 0
                //run function that tests completion for template
                //set each player's goalComplete value;
                return;
            default:
                //default template
                return;
        }
    }
    public bool winCompletionCheck()
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
    }
    public void template0()
    {
        ///This is where we determine which players have completed the goal for the first game template
    }
}
