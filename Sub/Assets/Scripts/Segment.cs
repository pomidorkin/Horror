using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] GameObject[] segmentDecorations;
    [SerializeField] GameObject[] staticDecorations;
    //[SerializeField] AllDoorController allDoorController;
    [SerializeField] CorridorLightSource[] lamps;
    [SerializeField] Door[] myDoors;
    public void ChangePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        SpawnRandomDecoration();
        LampFlickerTriggerRandom();
        //allDoorController.CloseAllDoors();
        CloseMyDoors();
    }

    private void SpawnRandomDecoration()
    {
        if (segmentDecorations.Length > 0)
        {
            foreach (GameObject segmentDecoration in segmentDecorations)
            {
                segmentDecoration.SetActive(false);

            }

            foreach (GameObject staticDecoration in staticDecorations)
            {
                staticDecoration.SetActive(false);

            }

            int rng = Random.Range(0, segmentDecorations.Length);

            segmentDecorations[rng].SetActive(true);
            staticDecorations[rng].SetActive(true);
        }
    }

    private void LampFlickerTriggerRandom()
    {
        foreach (CorridorLightSource lamp in lamps)
        {
            lamp.triggeredFlickering = false;
            int rnd = Random.Range(0, 100);
            if (rnd < 5)
            {
                lamp.triggeredFlickering = true;
            }
        }
    }

    private void CloseMyDoors()
    {
        foreach (Door door in myDoors)
        {
            door.CloseDoor();
        }
    }
}
