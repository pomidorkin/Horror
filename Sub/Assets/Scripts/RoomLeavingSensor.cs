using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLeavingSensor : MonoBehaviour
{
    private StageManager stageManager;
    private AllDoorController allDoorController;
    [SerializeField] RoomEnteringSensor roomEnteringSensor;
    private void Start()
    {
        stageManager = FindObjectOfType<StageManager>();
        allDoorController = FindObjectOfType<AllDoorController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            stageManager.currentStage.stageGoal.playerLeftTheRoom = true;
            allDoorController.CloseAllDoors();
            roomEnteringSensor.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
