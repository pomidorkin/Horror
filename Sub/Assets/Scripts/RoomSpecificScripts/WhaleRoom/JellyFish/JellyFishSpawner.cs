using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishSpawner : MonoBehaviour
{
    [SerializeField] GameObject jellyFishPrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] public Transform target;
    private float intervalCounter = 0;
    private float intervalLength = 20f;
    private float jellyFishInterval = 0;
    private float jellyFishIntervalLengh = 3f;

    private int jellyFishCounter = 0;
    private int jellyFishBatch = 3;

    // Update is called once per frame
    void Update()
    {
        if (intervalCounter < intervalLength)
        {
            intervalCounter += Time.deltaTime;
        }
        else
        {
            if (jellyFishInterval < jellyFishIntervalLengh)
            {
                jellyFishInterval += Time.deltaTime;
            }
            else
            {
                if (jellyFishCounter < jellyFishBatch)
                {
                    GameObject instance = Instantiate(jellyFishPrefab, spawnPosition.position, Quaternion.identity);
                    instance.transform.SetParent(this.transform);
                    jellyFishInterval = 0;
                    jellyFishCounter++;
                }
                else
                {
                    intervalCounter = 0;
                    jellyFishCounter = 0;
                }
                
            }
            
        }
    }
}
