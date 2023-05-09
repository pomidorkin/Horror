using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopInteractible : InteractionParent
{
    [SerializeField] GameObject targetObject;
    [SerializeField] GameObject interactionText;
    public override void ActivateInteractable()
    {
        targetObject.SetActive(true);
        interactionText.SetActive(false);
        MakeUninteractable();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
