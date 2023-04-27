using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinRiddleController : MonoBehaviour
{
    private bool mannequinPicked = false;
    private IndividualMannequin individualMannequin;

    public void PlaceMannequin(Vector3 newPos)
    {
        if (mannequinPicked)
        {
            individualMannequin.gameObject.SetActive(true);
            individualMannequin.transform.position = newPos;
            
            //mannequinPicked = false;
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
