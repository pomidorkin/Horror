using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadakoController : MonoBehaviour
{
    [SerializeField] TVSpawner TVSpawner;
    public void SpawnEnemy()
    {
        TVSpawner.SpawnSadakoEnemy();
    }
}
