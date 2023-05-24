using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnRoomLeavingCenter : MonoBehaviour
{
    [SerializeField] GameObject respawnRoom;
    [SerializeField] AllDoorController allDoorController;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] StageManager stageManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            allDoorController.CloseAllDoors();
            gameManager.SetRespawningStage(false);
            this.gameObject.SetActive(false);
            respawnRoom.SetActive(false);
            stageManager.currentStage.stageGoal.PlayerLeftRoom();
            Debug.Log("RespawnRoomLeavingSensor Has Been Triggered");
        }
    }
}
