using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TVSpawnerParent : MonoBehaviour
{
    [SerializeField] TVSpawner[] spawners;
    [SerializeField] Target target;

    float minTime = 5f;
    float maxTime = 8f;
    float nextTime = 6f;
    float counter = 0;

    public class CrossPlacedEventArgs : EventArgs
    {
        public bool IsCrossPlaced { get; set; }
    }

    public delegate void CrossPlaced(object source, CrossPlacedEventArgs args);
    public event CrossPlaced OnCrossPlaced;

    public delegate void DamageDealt();
    public event DamageDealt OnDamageDealt;

    // Update is called once per frame
    void Update()
    {
        // MaxTime should be random between 
        if (counter < nextTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            nextTime = UnityEngine.Random.Range(minTime, maxTime + 1);
            spawners[UnityEngine.Random.Range(0, spawners.Length)].AvtivateSpawnerSequence();
        }
    }

    public void CrossPaced(bool value)
    {
        OnCrossPlaced(this, new CrossPlacedEventArgs { IsCrossPlaced = value });
    }

    public void TargetDamageDealt()
    {
        Debug.Log("Throwing an event");
        OnDamageDealt();
    }

}
