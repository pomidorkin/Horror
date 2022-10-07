using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadakoGeneralController : MonoBehaviour
{
    private TVSpawnerParent TVSpawnerParent;
    [SerializeField] GameObject[] sadakoSkins;
    [SerializeField] TVSpawner TVSpawner;

    private void Start()
    {
        TVSpawnerParent = FindObjectOfType<TVSpawnerParent>();
    }
    public void ActivateSadakoSkin(int i)
    {
        sadakoSkins[i].SetActive(true);
    }

    public void Attack()
    {
        TVSpawnerParent.TargetDamageDealt();
    }

    public void SpawnEnemy()
    {
        TVSpawner.SpawnSadakoEnemy();
    }

}
