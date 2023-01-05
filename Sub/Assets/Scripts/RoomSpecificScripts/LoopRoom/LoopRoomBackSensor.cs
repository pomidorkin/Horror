using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRoomBackSensor : MonoBehaviour
{
    [SerializeField] LoopRoomController loopRoomController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            loopRoomController.AddLoop();
            this.gameObject.SetActive(false);
        }
    }
}
