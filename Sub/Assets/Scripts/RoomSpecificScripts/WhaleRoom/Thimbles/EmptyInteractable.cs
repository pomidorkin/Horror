using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInteractable : InteractionParent
{
    [SerializeField] PlayerThimblesController playerThimblesController;
    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        playerThimblesController.StartEndSequence();
    }
}
