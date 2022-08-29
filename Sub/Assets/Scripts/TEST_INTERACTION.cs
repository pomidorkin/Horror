using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TEST_INTERACTION : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    StageManager stageManager;
    string interactionText = "Interact";

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
    }

    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        Debug.Log("Mask");
    }

    private void CheckInteracted(RaycastHit hit)
    {
        if (hit.transform == this.transform)
        {
            stageManager.currentStage.stageGoal.MarkAsInteracted();
        }
    }

    public string GetInteractionText()
    {
        return interactionText;
    }
}
