using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossController : InteractionParent
{
    [SerializeField] TVSpawner TVSpawner;
    [SerializeField] GameObject playerCross;

    public CrossController()
    {
        this.interactionText = "Take The Cross";
    }
    public override void ActivateInteractable()
    {
        TVSpawner.crossIsPlaced = false;
        TVSpawner.TVSpawnerParent.CrossPaced(false);
        this.gameObject.SetActive(false);
        playerCross.gameObject.SetActive(true);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
