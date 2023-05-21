using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class TankManager : MonoBehaviour
{

    [SerializeField] RigBuilder rigBuilder;
    [SerializeField] TankMusicVisualizer tankMusicVisualizer;
    [SerializeField] GameObject turretInteraction;
    [SerializeField] GameObject flower;
    [SerializeField] AllTankController allTankController;
    private bool deactivated = false;

    private void Start()
    {
        allTankController.AddTankToList(this);
    }

    public void SetTankAimingEnabled(bool value)
    {
        rigBuilder.enabled = value;
        tankMusicVisualizer.enabled = value;
        deactivated = !value;

        if (value)
        {
            flower.SetActive(false);
            turretInteraction.SetActive(true);
        }
    }

    public bool GetDeactivated()
    {
        return deactivated;
    }

    public void Reset()
    {
        SetTankAimingEnabled(true);
    }
}
