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

    public delegate void LeverActivationTriggeredAction();
    public event LeverActivationTriggeredAction OnLeverActivatedAction;


    public void ChangeLastInteractedLever(IndependentLever lastLaver)
    {
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
                FindObjectOfType<StageManager>().currentStage.stageGoal.MarkAsInteracted();
            }
        }
    }
}
