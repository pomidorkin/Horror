using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System;

public class AllTankController : MonoBehaviour
{
    //[SerializeField] JellyFishSpawner jellyFishSpawner;
    [SerializeField] SenseiInteractable senseiInteractable;
    [SerializeField] WhalseSceneRespawnManager whalseSceneRespawnManager;
    [SerializeField] GameObject samuraiCutscene;
    private List<TankManager> tanks = new List<TankManager>();
    public bool allTanskDeactivated = false;

    public delegate void AllTanksDisabledAction();
    public event AllTanksDisabledAction OnAllTanksDisabled;

    private void OnEnable()
    {
        whalseSceneRespawnManager.OnRespawnAction += Respawn;
    }
    private void OnDisable()
    {
        whalseSceneRespawnManager.OnRespawnAction -= Respawn;
    }

    private void Respawn()
    {
        allTanskDeactivated = false;
        foreach (TankManager tank in tanks)
        {
            tank.Reset();
        }
    }

    public void AddTankToList(TankManager tank)
    {
        tanks.Add(tank);
    }

    public bool CheckIfAllTanksDeactivated()
    {
        bool allDeactivated = false;
        foreach (TankManager tank in tanks)
        {
            if (tank.GetDeactivated())
            {
                allDeactivated = true;
            }
            if (!tank.GetDeactivated())
            {
                allDeactivated = false;
                return false;
            }
        }
        allTanskDeactivated = true;
        OnAllTanksDisabled();
        samuraiCutscene.SetActive(true);
        senseiInteractable.MakeUninteractable();
        return allDeactivated;
    }
}
