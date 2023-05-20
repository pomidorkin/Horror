using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishSpawner : MonoBehaviour
{
    [SerializeField] GameObject jellyFishPrefab;
    [SerializeField] Transform spawnPosition;
    [SerializeField] public Transform target;
    [SerializeField] AllTankController allTankController;
    [SerializeField] GameObject portal;
    private float intervalCounter = 0;
    private float intervalLength = 20f;
    private float jellyFishInterval = 0;
    private float jellyFishIntervalLengh = 3f;
    private bool spawningAllowed = true;

    private int jellyFishCounter = 0;
    private int jellyFishBatch = 3;

    private void OnEnable()
    {
        allTankController.OnAllTanksDisabled += OnTanksDisabledHandler;
    }

    private void OnDisable()
    {
        allTankController.OnAllTanksDisabled -= OnTanksDisabledHandler;
    }

    private void OnTanksDisabledHandler()
    {
        spawningAllowed = false;
        portal.SetActive(false);
    }

    public AllTankController GetAllTankController()
    {
        return allTankController;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawningAllowed)
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

    public void DisableSpawning()
    {
        spawningAllowed = false;
    }
}
