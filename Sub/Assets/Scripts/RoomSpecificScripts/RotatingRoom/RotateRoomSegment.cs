using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoomSegment : MonoBehaviour
{
    [SerializeField] GameObject[] subRooms;
    [SerializeField] GameObject[] extraFloors;
    [SerializeField] GameObject[] nextDoorDecorations;
    [SerializeField] RotatingRoomDoor[] doors;

    public void RotateSegment()
    {
        CloseAllSubDoors();
        MakeAllSubRoomsActive();
        iTween.RotateBy(this.gameObject, iTween.Hash("z", .25, "easeType", "easeInOutBack", "time", 1.5f, "delay", .4));
    }

    private void MakeAllSubRoomsActive()
    {
        foreach (GameObject subRoom in subRooms)
        {
            subRoom.SetActive(true);
        }
        foreach (GameObject extraFloor in extraFloors)
        {
            extraFloor.SetActive(true);
        }
        foreach (GameObject nextDoorDecoration in nextDoorDecorations)
        {
            nextDoorDecoration.SetActive(false);
        }
    }

    private void CloseAllSubDoors()
    {
        foreach (RotatingRoomDoor door in doors)
        {
            door.CloseDoor();
        }
    }
}
