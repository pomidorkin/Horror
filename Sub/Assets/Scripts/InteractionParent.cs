using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.Localization;

public class InteractionParent : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private bool hideAfterInteraction = false;
    StageManager stageManager;
    protected bool interactable = true;
    //protected string interactionText = "Interact";
    public LocalizedString localizedInteractionText;

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

    public string GetInteractionText()
    {
        return localizedInteractionText.GetLocalizedString();
    }

    public void CheckInteracted(RaycastHit hit, bool val)
    {
        if (hit.transform == this.transform && interactable)
        {
            ActivateInteractable();
        }
    }

    public virtual void ActivateInteractable()
    {
        stageManager.currentStage.stageGoal.MarkAsInteracted();
        if (hideAfterInteraction)
        {
            gameObject.SetActive(false);
        }
    }

    public bool GetInteractable()
    {
        return interactable;
    }
}
