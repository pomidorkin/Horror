using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVInteractable : InteractionParent
{
    [SerializeField] GameObject cross;
    [SerializeField] TVSpawner TVSpawner;
    [SerializeField] GameObject playerCross;
    public TVInteractable()
    {
        this.interactionText = "Place The Cross";
    }


    public override void ActivateInteractable()
    {
        cross.gameObject.SetActive(true);
        TVSpawner.crossIsPlaced = true;
        TVSpawner.TVSpawnerParent.CrossPaced(true);
        playerCross.gameObject.SetActive(false);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
