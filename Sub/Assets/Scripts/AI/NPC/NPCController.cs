using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    //string interactionText = "Talk";
    public LocalizedString localizedInteractionText;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
    }

    private void CheckInteracted(RaycastHit hit, bool val)
    {
        if (hit.transform == this.transform)
        {
            Debug.Log("I am being talked to");
            dialogueTrigger.TriggerDialogue();
        }
    }

    public string GetInteractionText()
    {
        return localizedInteractionText.GetLocalizedString();
    }

    public bool GetInteractable()
    {
        return true;
    }
}