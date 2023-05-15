using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentLeverController : MonoBehaviour
{
    public IndependentLever lastInteractedLever;
    public bool solved = false;
    [SerializeField] int timesToInteract = 15;
    private int interactionCounter;
    [SerializeField] MovingCeiling movingCeiling;
    private bool thirdDoorActivated = false;

    public delegate void LeverActivationTriggeredAction();
    public event LeverActivationTriggeredAction OnLeverActivatedAction;


    public void ChangeLastInteractedLever(IndependentLever lastLaver)
    {
        if (!thirdDoorActivated)
        {
            thirdDoorActivated = true;
            movingCeiling.thirdDoor.SetActive(true);
        }
        if (lastLaver != lastInteractedLever && !solved)
        {
            lastInteractedLever = lastLaver;
            if (interactionCounter < timesToInteract)
            {
                interactionCounter++;
                OnLeverActivatedAction();
            }
            else
            {
                solved = true;
                // Puzzle solved
                movingCeiling.DisableMoving();
                movingCeiling.thirdDoor.SetActive(false);
                thirdDoorActivated = false;
                FindObjectOfType<StageManager>().currentStage.stageGoal.MarkAsInteracted();
            }
        }
    }

    public void SetDoorActivated(bool val)
    {
        thirdDoorActivated = val;
    }

    public void ResetInteractionCounter()
    {
        interactionCounter = 0;
    }
}
