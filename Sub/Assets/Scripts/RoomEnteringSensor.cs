using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomEnteringSensor : MonoBehaviour
{
    private StageManager stageManager;
    private AllDoorController allDoorController;
    [SerializeField] RoomLeavingSensor roomLeavingSensor;
    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        allDoorController = FindObjectOfType<AllDoorController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stageManager.currentStage.stageGoal.playerLeftTheRoom = false;
            allDoorController.CloseAllDoors();
            roomLeavingSensor.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
