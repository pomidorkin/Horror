using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThimblesController : MonoBehaviour
{
    [SerializeField] ThimblesController thimblesController;
    [SerializeField] SenseiInteractable senseiInteractable;
    private bool objectPicked = false;
    private bool fanPicked = false;
    private bool flowerPicked = false;
    [SerializeField] GameObject fanObject;
    public void SetFlowerPicked()
    {
        objectPicked = true;
        //senseiInteractable.enabled = false;
        senseiInteractable.MakeUninteractable();
    }

    public void SetFanPicked()
    {
        objectPicked = true;
        fanPicked = true;
        fanObject.SetActive(true);
        //senseiInteractable.enabled = false;
        senseiInteractable.MakeUninteractable();
    }

    public void ObjectPlaced()
    {
        //senseiInteractable.enabled = true;
        senseiInteractable.MakeInteractable();
        objectPicked = false;
    }

    public void MakeSenseiInteractable()
    {
        senseiInteractable.MakeInteractable();
    }

    public void StartEndSequence()
    {
        thimblesController.StartEndSequence();
    }

    public bool GetObjectPicked()
    {
        return objectPicked;
    }

    public bool GetFanPicked()
    {
        return fanPicked;
    }

    public void FanPicked(bool val)
    {
        fanPicked = val;
    }
}
