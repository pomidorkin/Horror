using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class IndividualMannequin : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] MannequinRiddleController riddleController;
    [SerializeField] public GameObject pickedMannequinModel;
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
                gameObject.SetActive(false);
                pickedMannequinModel.SetActive(true);
                if (locationMannequin != null)
                {
                    locationMannequin.gameObject.SetActive(true);
                    locationMannequin.ClearMyMannequin();
                    if (locationMannequin.marker != null && !locationMannequin.solved)
                    {
                        locationMannequin.marker.SetActive(true);
                    }
                    locationMannequin.SetInteractable(true);
                    locationMannequin.placedCorrectly = false;
                    locationMannequin = null;
                    Debug.Log("locationMannequin: " + locationMannequin);
                }
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
