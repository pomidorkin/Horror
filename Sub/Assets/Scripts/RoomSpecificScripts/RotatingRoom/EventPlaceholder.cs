using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventPlaceholder : MonoBehaviour
{
    [SerializeField] RotatingRoomDoor rotatingRoomDoor;

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
    }
}
