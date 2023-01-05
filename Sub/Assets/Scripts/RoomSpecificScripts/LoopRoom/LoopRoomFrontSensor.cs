using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRoomFrontSensor : MonoBehaviour
{
    [SerializeField] LoopRoomController loopRoomController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loopRoomController.MakeBackSensorACtive();
            this.gameObject.SetActive(false);
        }
    }
}
