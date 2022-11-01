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
            respawnRoom.SetActive(false);
            allDoorController.CloseAllDoors();
            gameManager.SetRespawningStage(false);
        }
    }
}
