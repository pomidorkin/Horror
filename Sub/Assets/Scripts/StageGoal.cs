using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StageGoal
{
    public Stage stage;
    public int requiredAmount;
    public float currentAmount;
    public int requiredDoorsInteractionNumber;
    public int currentDoorsInteractionNumber;
    public bool wasInteracted;
    public bool playerLeftTheRoom;

    public delegate void ReachGoalActiom();
    public static event ReachGoalActiom OnActionChanged;


    public void CheckIfGoalIsReached()
    {
        Debug.Log("CheckIfGoalIsReached");
        // HERE WE HAVE TO DEFINE CONDITIONS THAT WOULD BE NEEDED TO REACH THE GOAL

        if (stage.goalType == Stage.GoalType.amountGoal)
        {
            if (stage.stageLocationType == Stage.StageLocationType.room)
            {
                if ((int)currentAmount >= requiredAmount && playerLeftTheRoom)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            else if (stage.stageLocationType == Stage.StageLocationType.corridor)
            {
                if ((int)currentAmount >= requiredAmount)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            
        }

        else if (stage.goalType == Stage.GoalType.interactGoal)
        {
            if (stage.stageLocationType == Stage.StageLocationType.room)
            {
                if (wasInteracted && playerLeftTheRoom)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            else if (stage.stageLocationType == Stage.StageLocationType.corridor)
            {
                if (wasInteracted)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            
        }

        else if (stage.goalType == Stage.GoalType.bothAmountInteract)
        {
            if (stage.stageLocationType == Stage.StageLocationType.room)
            {
                if (wasInteracted && playerLeftTheRoom && (int)currentAmount >= requiredAmount)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            else if (stage.stageLocationType == Stage.StageLocationType.corridor)
            {
                if (wasInteracted && (int)currentAmount >= requiredAmount)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }

        }

        else if (stage.goalType == Stage.GoalType.doorsAndAmount)
        {
            if (stage.stageLocationType == Stage.StageLocationType.room)
            {
                if (playerLeftTheRoom && (int)currentAmount >= requiredAmount && currentDoorsInteractionNumber >= requiredDoorsInteractionNumber)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
            else if (stage.stageLocationType == Stage.StageLocationType.corridor)
            {
                if ((int)currentAmount >= requiredAmount && currentDoorsInteractionNumber >= requiredDoorsInteractionNumber)
                {
                    SetGoalsToDefault();
                    ReachTheGoal();
                }
            }
        }
    }

    private void SetGoalsToDefault()
    {
        currentDoorsInteractionNumber = 0;
        currentAmount = 0;
        wasInteracted = false;
        playerLeftTheRoom = false;
    }

    public void PlayerLeftRoom()
    {
        playerLeftTheRoom = true;
        CheckIfGoalIsReached();
    }
    public void ReachTheGoal()
    {
        OnActionChanged();
    }

    public void SetCurrentAmount(float value)
    {
        currentAmount = value;
        CheckIfGoalIsReached();
    }

    public void AddDoorsInteractionNumber()
    {
        currentDoorsInteractionNumber++;
        CheckIfGoalIsReached();
    }

    public void MarkAsInteracted()
    {
        wasInteracted = true;
        CheckIfGoalIsReached();
    }

}
