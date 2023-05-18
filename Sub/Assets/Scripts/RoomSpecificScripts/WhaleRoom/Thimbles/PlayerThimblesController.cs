using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThimblesController : MonoBehaviour
{
    [SerializeField] ThimblesController thimblesController;
    [SerializeField] SenseiInteractable senseiInteractable;
    private bool objectPicked = false;
    public void SetFlowerPicked()
    {
        objectPicked = true;
        //senseiInteractable.enabled = false;
        senseiInteractable.MakeUninteractable();
    }

    public void SetFanPicked()
    {
        objectPicked = true;
        //senseiInteractable.enabled = false;
        senseiInteractable.MakeUninteractable();
    }

    public void ObjectPlaced()
    {
        //senseiInteractable.enabled = true;
        senseiInteractable.MakeInteractable();
        objectPicked = false;
    }

    public void StartEndSequence()
    {
        thimblesController.StartEndSequence();
    }
}
