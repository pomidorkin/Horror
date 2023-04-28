using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinRiddleController : MonoBehaviour
{
    private bool mannequinPicked = false;
    private IndividualMannequin individualMannequin;

    public void PlaceMannequin(Transform newLoc)
    {
        if (mannequinPicked)
        {
            individualMannequin.gameObject.SetActive(true);
            individualMannequin.transform.position = newLoc.position;
            individualMannequin.transform.rotation = newLoc.rotation;
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
    }

    public IndividualMannequin GetCurrentMannequin()
    {
        return individualMannequin;
    }
}
