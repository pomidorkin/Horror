using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideInteractionExit : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] HideInteraction hideInteraction;
    protected bool interactable = true;
    protected string interactionText = "Exit";
    public bool GetInteractable()
    {
        return interactable;
    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
    }

    public void CheckInteracted(RaycastHit hit, bool val)
    {
        if (hit.transform == this.transform && interactable)
        {
            ActivateInteractable();
        }
    }

    public void ActivateInteractable()
    {
        //hideInteraction.ExitHidingPlace();
        hideInteraction.PlayExitingAnim();
    }

    /*public void DeactivateExitCollider()
    {
        gameObject.SetActive(false);
    }*/
}
