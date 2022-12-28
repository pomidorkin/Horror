using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRoomLeavingCenter : MonoBehaviour
{
    [SerializeField] GameObject respawnRoom;
    [SerializeField] AllDoorController allDoorController;
    [SerializeField] GameManagerScript gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            allDoorController.CloseAllDoors();
            gameManager.SetRespawningStage(false);
            this.gameObject.SetActive(false);
            respawnRoom.SetActive(false);
            Debug.Log("RespawnRoomLeavingSensor Has Been Triggered");
        }
    }
}
