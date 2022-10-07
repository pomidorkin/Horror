using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadakoGeneral : MonoBehaviour
{
    [SerializeField] TVSpawner TVSpawner;
    public void SpawnEnemy()
    {
        TVSpawner.SpawnSadakoEnemy();
    }
}
