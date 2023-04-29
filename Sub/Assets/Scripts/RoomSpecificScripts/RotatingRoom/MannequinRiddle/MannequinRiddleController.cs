using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinRiddleController : MonoBehaviour
{
    private bool mannequinPicked = false;
    private IndividualMannequin individualMannequin;

    public delegate void MannequinPickedAction();
    public event MannequinPickedAction OnMannequinPicked;

    public delegate void MannequinPlacedAction();
    public event MannequinPickedAction OnMannequinPlaced;

    public void PlaceMannequin(Transform newLoc)
    {
        if (mannequinPicked)
        {
            individualMannequin.gameObject.SetActive(true);
            individualMannequin.transform.position = newLoc.position;
            individualMannequin.transform.rotation = newLoc.rotation;
            individualMannequin.pickedMannequinModel.SetActive(false);
            OnMannequinPlaced();
        }
    }

    public bool GetMannequinPicked()
    {
        return mannequinPicked;
    }

    public void SetMannequinPicked(bool val)
    {
        individualMannequin = null;
        mannequinPicked = val;
    }

    public void PickMannequin(IndividualMannequin mannequinObject)
    {
        individualMannequin = mannequinObject;
        mannequinPicked = true;
        OnMannequinPicked();
        Debug.Log("OnMannequinPicked();");
    }

    public IndividualMannequin GetCurrentMannequin()
    {
        return individualMannequin;
    }
}
