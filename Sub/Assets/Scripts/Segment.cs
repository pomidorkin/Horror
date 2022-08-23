using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    [SerializeField] GameObject[] segmentDecorations;
    [SerializeField] CorridorLightSource[] lamps;
    public void ChangePosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        SpawnRandomDecoration();
        LampFlickerTriggerRandom();
    }

    private void SpawnRandomDecoration()
    {
        if (segmentDecorations.Length > 0)
        {
            foreach (GameObject segmentDecoration in segmentDecorations)
            {
                segmentDecoration.SetActive(false);
            }

            segmentDecorations[Random.Range(0, segmentDecorations.Length)].SetActive(true);
        }
    }

    private void LampFlickerTriggerRandom()
    {
        foreach (CorridorLightSource lamp in lamps)
        {
            lamp.triggeredFlickering = false;
            int rnd = Random.Range(0, 10/*0*/);
            if (rnd < 5)
            {
                lamp.triggeredFlickering = true;
            }
        }
    }
}
