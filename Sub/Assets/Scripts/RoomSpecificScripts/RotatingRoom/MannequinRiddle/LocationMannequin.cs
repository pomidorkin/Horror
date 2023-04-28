using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class LocationMannequin : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] MannequinRiddleController riddleController;
    [SerializeField] IndividualMannequin[] correctMannequins;
    public LocalizedString localizedInteractionText;
    private bool interactable = true;
    [SerializeField] RiddleProgressTracker riddleProgressTracker;
    [SerializeField] LocationMannequin[] counterparts;
    public bool placedCorrectly = false;
    [SerializeField] public GameObject marker;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += PlaceMannequin;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= PlaceMannequin;
    }
    private void PlaceMannequin(RaycastHit hit, bool isRespawnStage)
    {
        if (hit.transform == this.transform && interactable)
        {
            riddleController.PlaceMannequin(this.transform);
            interactable = false;

            if (correctMannequins.Length > 0)
            {
            foreach (IndividualMannequin correctMannequin in correctMannequins)
            {
                if (correctMannequin == riddleController.GetCurrentMannequin())
                {
                    correctMannequin.SetInteractable(false);
                    placedCorrectly = true;
                    foreach (LocationMannequin otherMannequin in counterparts)
                    {
                        if (otherMannequin.placedCorrectly)
                        {
                            riddleProgressTracker.allSolvedCorrectrly = true;
                        }
                        else
                        {
                            riddleProgressTracker.allSolvedCorrectrly = false;
                        }
                    }
                    riddleProgressTracker.RiddleStepSolved();
                    break;
                }
            }
            }
            riddleController.GetCurrentMannequin().SetCurrectLocationMannequin(this);
            riddleController.SetMannequinPicked(false);
            if (marker != null)
            {
                marker.SetActive(false);
            }
            gameObject.SetActive(false);
        }
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
