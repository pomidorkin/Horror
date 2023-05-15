using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class IndependentLever : MonoBehaviour, IInteractable
{
    [SerializeField] IndependentLeverController leverController;
    private Animator animator;
    private bool turnedDown = false;
    public LocalizedString localizedInteractionText;
    [SerializeField] private PlayerActions playerActions;
    private bool interactable = true;
    private void OnEnable()
    {
        leverController.OnLeverActivatedAction += LaverActivatedHandler;
        playerActions.OnInteractedAction += ActivateInteractable;
    }
    private void OnDisable()
    {
        leverController.OnLeverActivatedAction -= LaverActivatedHandler;
        playerActions.OnInteractedAction -= ActivateInteractable;
    }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void LaverActivatedHandler()
    {
        if (leverController.lastInteractedLever != this)
        {
            Debug.Log("LaverActivatedHandler called");
            int rnd = UnityEngine.Random.Range(1, 3);
            if (rnd < 2)
            {
                if (turnedDown)
                {
                    CloseLever();
                }
                else
                {
                    OpenLever();
                }
            }
        }
    }

    
    public void ActivateInteractable(RaycastHit hit, bool isRespawnStage)
    {
        if (hit.transform == this.transform && interactable)
        {
            Debug.Log("ActivateInteractable");
            if (!leverController.solved)
            {
                if (turnedDown == false)
                {
                    Debug.Log("Playing OpenLever anim");
                    OpenLever();

                }
                else
                {
                    Debug.Log("Playing CloseLever anim");
                    CloseLever();
                }
                leverController.ChangeLastInteractedLever(this);

            }
        }
    }

    private void OpenLever()
    {
        turnedDown = true;
        animator.Play("LeverOpenAnimation");
    }

    public void CloseLever()
    {
        turnedDown = false;
        animator.Play("LeverCloseAnimation");
    }
    public string GetInteractionText()
    {
        return localizedInteractionText.GetLocalizedString();
    }

    public bool GetInteractable()
    {
        return interactable;
    }
}