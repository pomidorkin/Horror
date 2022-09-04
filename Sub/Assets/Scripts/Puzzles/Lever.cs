using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : InteractionParent
{
    [SerializeField] LeverPuzzle leverPuzzle;
    public Lever()
    {
        this.interactionText = "Activate";
    }

    public override void ActivateInteractable()
    {
        leverPuzzle.CheckCorrectLever(this);
    }
}
