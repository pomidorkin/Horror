using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomParent : MonoBehaviour
{
    [SerializeField] public Stage.StageType myStageType;
    [SerializeField] private StageManager stageManager;
    [SerializeField] public GameObject childRoom;
    [SerializeField] private DoorManager doorManager;
    bool isRotated = false;
    private void OnEnable()
    {
        stageManager.OnStageChangedAction += CheckChangedStage;
        doorManager.OnDoorOpenedEvent += SetRoomPosition;
    }

    private void OnDisable()
    {
        stageManager.OnStageChangedAction -= CheckChangedStage;
        doorManager.OnDoorOpenedEvent -= SetRoomPosition;
    }

    private void SetRoomPosition(object source, DoorManager.DoorOpenedEventArgs args)
    {
        if (myStageType == stageManager.currentStage.currentStage)
        {
            // Rotating room 180 degrees if the room is on the right
            if (args.IsRightDoor && !isRotated)
            {
                gameObject.transform.rotation *= Quaternion.Euler(0, 180f, 0);
                isRotated = true;
            }
            else if (!args.IsRightDoor && isRotated)
            {
                gameObject.transform.rotation *= Quaternion.Euler(0, -180f, 0);
                isRotated = false;
            }
            gameObject.transform.position = args.PositinToSpawnTheRoom.position;
        }
        Debug.Log("SetRoomPosition(); " + "myStageType: " + myStageType + "stageManager.currentStage.currentStage: " + stageManager.currentStage.currentStage);
    }

    private void CheckChangedStage(object source, StageManager.StangeChangedActionEventArgs args)
    {
        Debug.Log("CheckChangedStage();");
        SpawnRoom(args.CurrentStage);
    }

    public void SpawnRoom(Stage stage)
    {
            Debug.Log("SpawnRoom");
            if (stage.currentStage == myStageType)
            {
                childRoom.SetActive(true);
            }
            else
            {
                if (childRoom.activeInHierarchy)
                {
                    childRoom.SetActive(false);
                }
            }
        
    }

    public void SpawnRespawnRoom()
    {
        Debug.Log("SpawnRespawnRoom");
        /*if (myStageType == Stage.StageType.respawnStage)
        {
            childRoom.SetActive(true);
        }
        else
        {
            if (childRoom.activeInHierarchy)
            {
                childRoom.SetActive(false);
            }
        }*/
        childRoom.SetActive(true);
    }

    public void SpawnRoom(bool active)
    {
        childRoom.gameObject.SetActive(active);
        Debug.Log("SpawnRoom(" + active + ");");
    }
}
