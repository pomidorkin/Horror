using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVInteractable : InteractionParent
{
    [SerializeField] GameObject cross;
    public TVInteractable()
    {
        this.interactionText = "Place The Cross";
    }


    public override void ActivateInteractable()
    {
        cross.gameObject.SetActive(true);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
