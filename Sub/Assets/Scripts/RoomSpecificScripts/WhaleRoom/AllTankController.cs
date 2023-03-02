using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class AllTankController : MonoBehaviour
{
    private List<TankManager> tanks = new List<TankManager>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        return allDeactivated;
    }
}
