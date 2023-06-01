using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunesController : MonoBehaviour
{
    [SerializeField] RuneFloorButton[] runeButtons;
    private bool allPressed = false;

    public void CheckIfAllActive()
    {
        allPressed = true;
        foreach (RuneFloorButton runeButton in runeButtons)
        {
            if (!runeButton.GetIsPressed())
            {
                allPressed = false;
            }
        }

        if (allPressed)
        {
            Debug.Log("Open Gate");
        }
    }
}
