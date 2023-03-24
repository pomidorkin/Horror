using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeActiveInteractable : InteractionParent
{
    [SerializeField] GameObject targetObject;
    [SerializeField] GameManagerScript gameManager;

    public override void ActivateInteractable()
    {
        targetObject.SetActive(true);
        gameManager.DisablePlayerActions();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
