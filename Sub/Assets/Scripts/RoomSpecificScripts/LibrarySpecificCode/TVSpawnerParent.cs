using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TVSpawnerParent : MonoBehaviour
{
    [SerializeField] TVSpawner[] spawners;

    float maxTime = 5f;
    float counter = 0;

    public class CrossPlacedEventArgs : EventArgs
    {
        public bool IsCrossPlaced { get; set; }
    }

    public delegate void CrossPlaced(object source, CrossPlacedEventArgs args);
    public event CrossPlaced OnCrossPlaced;

    // Update is called once per frame
    void Update()
    {
        // MaxTime should be random between 
        if (counter < maxTime)
        {
            counter += Time.deltaTime;
        }
        else
        {
            counter = 0;
            spawners[UnityEngine.Random.Range(0, spawners.Length)].AvtivateSpawnerSequence();
        }
    }

    public void CrossPaced(bool value)
    {
        OnCrossPlaced(this, new CrossPlacedEventArgs { IsCrossPlaced = value });
    }

}
