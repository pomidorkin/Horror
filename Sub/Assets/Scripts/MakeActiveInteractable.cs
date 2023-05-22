using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveInteractable : InteractionParent
{
    [SerializeField] GameObject targetObject;

    public override void ActivateInteractable()
    {
        targetObject.SetActive(true);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
