using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseiInteractable : InteractionParent
{
    [SerializeField] ThimblesController thimblesController;
    public override void ActivateInteractable()
    {
        thimblesController.StartThimblesSequence();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
