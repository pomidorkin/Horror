using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : InteractionParent
{
    [SerializeField] LightSwitch lightSwitch;
    public SwitchInteraction()
    {
        this.interactionText = "Lights On/Off";
    }


    public override void ActivateInteractable()
    {
        lightSwitch.ToggleSwitchOnOff();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
