using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class IndividualMannequin : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] MannequinRiddleController riddleController;
    private LocationMannequin locationMannequin;
    public LocalizedString localizedInteractionText;
    private bool interactable = true;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += PickThisMannequin;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= PickThisMannequin;
    }
    private void PickThisMannequin(RaycastHit hit, bool isRespawnStage)
    {
        if (!riddleController.GetMannequinPicked() && interactable)
        {
            if (hit.transform == this.transform && interactable)
            {
                riddleController.PickMannequin(this);
                //interactable = false;
                gameObject.SetActive(false);
            }
            if (locationMannequin != null)
            {
                locationMannequin.gameObject.SetActive(true);
                locationMannequin.SetInteractable(true);
            }
        }
    }

    public void SetCurrectLocationMannequin(LocationMannequin locationMannequin)
    {
        this.locationMannequin = locationMannequin;
    }

    public void SetInteractable(bool val)
    {
        interactable = val;
    }
    public bool GetInteractable()
    {
        return interactable;
    }

    public string GetInteractionText()
    {
        return localizedInteractionText.GetLocalizedString();
    }
}
