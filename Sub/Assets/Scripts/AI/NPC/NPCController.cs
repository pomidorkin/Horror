using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    string interactionText = "Talk";

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
    }

    private void CheckInteracted(RaycastHit hit)
    {
        if (hit.transform == this.transform)
        {
            Debug.Log("I am being talked to");
            dialogueTrigger.TriggerDialogue();
        }
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    public bool GetInteractable()
    {
        return true;
    }
}