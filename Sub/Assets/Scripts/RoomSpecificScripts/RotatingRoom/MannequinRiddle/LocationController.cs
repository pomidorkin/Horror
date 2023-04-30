using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationController : MonoBehaviour
{
    [SerializeField] LocationMannequin[] childLocations;

    public void MarkChildLocationsSolved()
    {
        foreach (LocationMannequin childLocation in childLocations)
        {
            childLocation.solved = true;
            childLocation.GetComponent<Collider>().enabled = false;
        }
    }
}
