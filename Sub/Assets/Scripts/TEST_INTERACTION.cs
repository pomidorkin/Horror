using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class TEST_INTERACTION : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private bool hideAfterInteraction = false;
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
            ActivateInteractable();
        }
    }

    private void ActivateInteractable()
    {
        stageManager.currentStage.stageGoal.MarkAsInteracted();
        if (hideAfterInteraction)
        {
            gameObject.SetActive(false);
        }
    }

    public string GetInteractionText()
    {
        return interactionText;
    }
}
