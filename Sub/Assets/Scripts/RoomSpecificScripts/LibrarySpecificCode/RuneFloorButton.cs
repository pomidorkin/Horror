using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneFloorButton : MonoBehaviour
{
    [SerializeField] RunesController runesController;
    private bool isPressed = false;
    private string activator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "TVMonster")
        {
            activator = other.tag;
            isPressed = true;
            runesController.CheckIfAllActive();
            // Change object to active
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == activator)
        {
            activator = "";
            isPressed = false;
        }
        
    }

    public bool GetIsPressed()
    {
        return isPressed;
    }
}
