using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractionParent
{
    [SerializeField] private LeverPuzzle leverPuzzle;
    private Animator animator;
    public bool turnedDown = false;
    private bool firstLever = false;

    public Lever()
    {
        this.interactionText = "Activate";
    }

    private void Start()
    {
        firstLever = leverPuzzle.levers[0] == this;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        if (!leverPuzzle.solved)
        {
            if (!turnedDown)
            {
                if (firstLever)
                {
                    leverPuzzle.CloseAllLevers();
                }
                animator.Play("LeverOpenAnimation");
                leverPuzzle.CheckCorrectLever(this);
                turnedDown = true;
            }
            else
            {
                CloseLever();
            }
            
        }
    }

    public void CloseLever()
    {
        turnedDown = false;
        animator.Play("LeverCloseAnimation");
    }
}
