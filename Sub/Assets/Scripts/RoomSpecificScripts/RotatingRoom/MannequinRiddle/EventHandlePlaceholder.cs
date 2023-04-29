using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlePlaceholder : MonoBehaviour
{
    [SerializeField] MannequinRiddleController riddleController;
    [SerializeField] RotationLever rotationLever;

    private void OnEnable()
    {
        riddleController.OnMannequinPicked += MannequinPickedHandler;
        riddleController.OnMannequinPlaced += MannequinPlaceddHandler;
    }

    private void OnDisable()
    {
        riddleController.OnMannequinPicked -= MannequinPickedHandler;
        riddleController.OnMannequinPlaced -= MannequinPlaceddHandler;
    }

    private void MannequinPlaceddHandler()
    {
    }

    private void MannequinPickedHandler()
    {
    }
}
