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
    private bool interactable = false;
    [SerializeField] RiddleProgressTracker riddleProgressTracker;
    [SerializeField] LocationMannequin[] counterparts;
    public bool placedCorrectly = false;
    [SerializeField] public GameObject marker;
    private IndividualMannequin myMannequin;
    public bool solved = false;
    private Collider myCollider;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += PlaceMannequin;
        riddleController.OnMannequinPicked += MannequinPickedHandler;
        riddleController.OnMannequinPlaced += MannequinPlaceddHandler;
        //riddleProgressTracker.OnStepSolved += OnStepSolvedHandler;
        if (myCollider == null)
        {
            myCollider = gameObject.GetComponent<Collider>();
        }
        if (myMannequin != null)
        {
            myMannequin.gameObject.SetActive(true);
        }
        if (riddleController.GetMannequinPicked() && !interactable && !solved)
        {
            interactable = true;
            myCollider.enabled = true;
        }
        
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= PlaceMannequin;
        riddleController.OnMannequinPicked -= MannequinPickedHandler;
        riddleController.OnMannequinPlaced -= MannequinPlaceddHandler;
        //riddleProgressTracker.OnStepSolved -= OnStepSolvedHandler;
        Debug.Log("myMannequin is null = " + (myMannequin == null));
        if (myMannequin != null)
        {
            myMannequin.gameObject.SetActive(false);
        }
    }

    /*private void OnStepSolvedHandler()
    {
        ClearMyMannequin();
    }*/
    private void PlaceMannequin(RaycastHit hit, bool isRespawnStage)
    {
        if (hit.transform == this.transform && interactable)
        {
            riddleController.PlaceMannequin(this.transform);
            interactable = false;
            myCollider.enabled = false;

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
                                //riddleProgressTracker.allSolvedCorrectrly = true;
                                riddleProgressTracker.solvedCorrectly++;
                        }
                        else
                        {
                            //riddleProgressTracker.allSolvedCorrectrly = false;
                        }
                    }
                    riddleProgressTracker.RiddleStepSolved();
                    break;
                }
            }
            }
            Debug.Log("riddleController.GetCurrentMannequin() is null = " + riddleController.GetCurrentMannequin() == null);
            Debug.Log("riddleController.GetMannequinPicked(): " + riddleController.GetMannequinPicked());

            if (riddleController.GetCurrentMannequin() != null && riddleController.GetMannequinPicked())
            {
                myMannequin = riddleController.GetCurrentMannequin();
                Debug.Log("myMannequin = " + myMannequin);
            }
            riddleController.GetCurrentMannequin().SetCurrectLocationMannequin(this);
            riddleController.SetMannequinPicked(false);
            if (marker != null)
            {
                marker.SetActive(false);
            }
            interactable = false; // test
            myCollider.enabled = false;
            //gameObject.SetActive(false);
        }
    }

    public void ClearMyMannequin()
    {
        myMannequin = null;
    }

    private void MannequinPickedHandler()
    {
        Debug.Log("MannequinPickedHandler();");
        interactable = true;
        if (myCollider != null)
        {
            myCollider.enabled = true;
        }
        
    }

    private void MannequinPlaceddHandler()
    {
        interactable = false;
        if (myCollider != null)
        {
            myCollider.enabled = false;
        }
    }

    public void SetInteractable(bool val)
    {
        if (!solved)
        {
            interactable = val;
            if (myCollider != null)
            {
                myCollider.enabled = val;
            }
        }
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
