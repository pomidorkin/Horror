using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorClosingSensor : MonoBehaviour
{
    [SerializeField] ElevatorController elevatorController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            elevatorController.CloseElevatorDoors();
        }
    }
}
