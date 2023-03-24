using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentLever : InteractionParent
{
    [SerializeField] IndependentLeverController leverController;
    private Animator animator;
    public bool turnedDown = false;

    private void OnDisable()
    {
        leverController.OnLeverActivatedAction -= LaverActivatedHandler;
    }

    void Start()
    {
        leverController.OnLeverActivatedAction += LaverActivatedHandler;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    private void LaverActivatedHandler()
    {
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

    
    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        if (!leverController.solved)
        {
            if (!turnedDown)
            {
                OpenLever();
                leverController.ChangeLastInteractedLever(this);
            }
            else
            {
                CloseLever();
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
}