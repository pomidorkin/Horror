using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinController : MonoBehaviour
{
    [SerializeField] RotatingRoomDoor rotatingRoomDoor;
    [SerializeField] GameObject mannequin;

    private void OnEnable()
    {
        rotatingRoomDoor.OnRotatingDoorOpened += OnDoorOpenedHandler;
    }

    private void OnDisable()
    {
        rotatingRoomDoor.OnRotatingDoorOpened -= OnDoorOpenedHandler;
    }

    private void OnDoorOpenedHandler()
    {
        mannequin.SetActive(true);
    }
}
