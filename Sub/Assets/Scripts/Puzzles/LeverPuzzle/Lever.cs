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
    [SerializeField] int leverPuzzleIndex;

    public Lever()
    {
        this.interactionText = "Activate";
    }

    private void Start()
    {
        //firstLever = leverPuzzle.levers_1[0] == this;
        firstLever = leverPuzzle.leversArray[leverPuzzleIndex][0] == this;
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        if (!leverPuzzle.solved[leverPuzzleIndex])
        {
            if (!turnedDown)
            {
                if (firstLever)
                {
                    leverPuzzle.CloseAllLevers(leverPuzzleIndex);
                }
                animator.Play("LeverOpenAnimation");
                leverPuzzle.CheckCorrectLever(this, leverPuzzleIndex);
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
