using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtons : InteractionParent
{
    [SerializeField] ElevatorController elevatorController;
    public ElevatorButtons()
    {
        this.interactionText = "Press the Button";
    }
    

    public override void ActivateInteractable()
    {
        elevatorController.LoandScene();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
