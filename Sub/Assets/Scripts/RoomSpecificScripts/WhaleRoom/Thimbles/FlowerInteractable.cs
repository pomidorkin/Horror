using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerInteractable : InteractionParent
{
    [SerializeField] PlayerThimblesController playerThimblesController;
    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        playerThimblesController.SetFlowerPicked();
        playerThimblesController.StartEndSequence();
    }
}
