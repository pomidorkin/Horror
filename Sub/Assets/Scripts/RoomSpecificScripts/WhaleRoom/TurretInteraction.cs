using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretInteraction : InteractionParent
{
    [SerializeField] GameObject targetObject;
    [SerializeField] TankManager tankManager;
    [SerializeField] AllTankController AllTankController;
    [SerializeField] PlayerThimblesController playerThimblesController;

    public override void ActivateInteractable()
    {
        if (playerThimblesController.GetFlowerPicked())
        {
            PutFlower();
            playerThimblesController.FlowerPicked(false);
        }
    }

    private void PutFlower()
    {
        targetObject.SetActive(true);
        tankManager.SetTankAimingEnabled(false);
        Debug.Log("All Tanks Are Deactivated: " + AllTankController.CheckIfAllTanksDeactivated());
        this.gameObject.SetActive(false);
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }
}
