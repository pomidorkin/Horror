using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRoomController : MonoBehaviour
{
    [SerializeField] private int numberOfLoops = 6;
    [SerializeField] LoopRoomBackSensor loopRoomBackSensor;
    [SerializeField] LoopRoomFrontSensor loopRoomFrontSensor;
    [SerializeField] GameObject frontWallSolid;
    [SerializeField] GameObject frontWallDoor;
    [SerializeField] GameObject[] loopRoomStages;
    private int loopCounter = 0;

    public void AddLoop()
    {
        if (loopCounter < numberOfLoops)
        {
            loopCounter++;
            loopRoomFrontSensor.gameObject.SetActive(true);
        }
        else
        {
            // Level passed
        }

        //DeactivateAllStages();

        switch (loopCounter)
        {
            case 1:
                frontWallSolid.SetActive(true);
                frontWallDoor.SetActive(false);
                break;
            case 2:
                // Add some logic after each loop
                loopRoomStages[0].gameObject.SetActive(true);
                break;
            case 3:
                loopRoomStages[1].gameObject.SetActive(true);
                break;
            case 4:
                frontWallSolid.SetActive(false);
                frontWallDoor.SetActive(true);
                break;
            default:
                // code block
                break;
        }

    }

    public void MakeBackSensorACtive()
    {
        loopRoomBackSensor.gameObject.SetActive(true);
    }

    private void DeactivateAllStages()
    {
        foreach (GameObject roomStage in loopRoomStages)
        {
            roomStage.gameObject.SetActive(false);
        }
    }
}
