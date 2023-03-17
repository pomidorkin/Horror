using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : InteractionParent
{
    [SerializeField] GameObject steamEffect;
    [SerializeField] GameObject collisionTrigger;
    [SerializeField] GalateaController galateaController;

    public Valve()
    {
        this.interactionText = "Turn";
    }

    public override void ActivateInteractable()
{
        // Minigame should be initiated
        steamEffect.SetActive(false);
        collisionTrigger.SetActive(false);
        galateaController.EnableMotion();
        MakeUninteractable();
}

public void MakeUninteractable()
{
    this.interactable = false;
}
}
