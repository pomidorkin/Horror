using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NunCrossInteractible : InteractionParent
{
    [SerializeField] GameObject secondCamCross;
    [SerializeField] TVSpawnerParent TVSpawnerParent;
    public override void ActivateInteractable()
    {
        gameObject.SetActive(false);
        secondCamCross.SetActive(true);
        TVSpawnerParent.crossPicked = true;
    }
}
