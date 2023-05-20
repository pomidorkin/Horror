using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThimblesController : MonoBehaviour
{
    [SerializeField] ThimblesController thimblesController;
    [SerializeField] SenseiInteractable senseiInteractable;
    [SerializeField] AllTankController allTankController;
    private bool objectPicked = false;
    private bool fanPicked = false;
    private bool flowerPicked = false;
    [SerializeField] GameObject fanObject;
    [SerializeField] GameObject flowerObject;
    public void SetFlowerPicked()
    {
        Debug.Log("SetFlowerPicked");
        objectPicked = true;
        flowerPicked = true;
        flowerObject.SetActive(true);
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

    public bool GetFlowerPicked()
    {
        return flowerPicked;
    }

    public void FlowerPicked(bool val)
    {
        if (val == false)
        {
            if (!allTankController.allTanskDeactivated)
            {
                MakeSenseiInteractable();
            }
            flowerObject.SetActive(false);
        }
        flowerPicked = val;
    }

    public void FanPicked(bool val)
    {
        fanPicked = val;
    }
}
