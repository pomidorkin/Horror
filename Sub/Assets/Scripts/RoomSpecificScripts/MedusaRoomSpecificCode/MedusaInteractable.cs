using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaInteractable : InteractionParent
{
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject interactionTest;

    public MedusaInteractable()
    {
        this.interactionText = "Activate Medusa";
    }

    public override void ActivateInteractable()
    {
        targetObject.SetActive(true);
        interactionTest.SetActive(false);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
