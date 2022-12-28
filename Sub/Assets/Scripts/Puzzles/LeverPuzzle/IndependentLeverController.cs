using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentLeverController : MonoBehaviour
{
    public IndependentLever lastInteractedLever;
    public bool solved = false;
    [SerializeField] int timesToInteract = 10;
    private int interactionCounter;

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
                FindObjectOfType<StageManager>().currentStage.stageGoal.MarkAsInteracted();
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
