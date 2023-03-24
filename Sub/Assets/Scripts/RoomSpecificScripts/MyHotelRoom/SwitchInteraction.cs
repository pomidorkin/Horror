using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInteraction : InteractionParent
{
    [SerializeField] LightSwitch lightSwitch;


    public override void ActivateInteractable()
    {
        lightSwitch.ToggleSwitchOnOff();
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
