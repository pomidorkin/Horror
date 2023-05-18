using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanInteractable : InteractionParent
{
    [SerializeField] PlayerThimblesController playerThimblesController;
    
    public override void ActivateInteractable()
    {
        Debug.Log("ActivateInteractable");
        playerThimblesController.SetFanPicked();
        playerThimblesController.StartEndSequence();
    }
}
