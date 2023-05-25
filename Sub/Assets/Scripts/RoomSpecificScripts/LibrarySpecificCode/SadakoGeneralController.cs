using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadakoGeneralController : MonoBehaviour
{
    private TVSpawnerParent TVSpawnerParent;
    [SerializeField] GameObject[] sadakoSkins;
    [SerializeField] TVSpawner TVSpawner;
    [SerializeField] GameObject explosionVFX;
    //private bool switchedOff = true;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private bool enemySpawned = false;

    private void Awake()
    {
        TVSpawnerParent = FindObjectOfType<TVSpawnerParent>();
    }

    private void Start()
    {
        //TVSpawnerParent = FindObjectOfType<TVSpawnerParent>();
        //TVSpawnerParent.audioVisualizerManager.OnPeakReachedAction += SwitchVisibility;
        TVSpawnerParent.OnBroadcastPeak += SwitchVisibility;
    }

    private void OnDisable()
    {
        //TVSpawnerParent.audioVisualizerManager.OnPeakReachedAction -= SwitchVisibility;
        TVSpawnerParent.OnBroadcastPeak -= SwitchVisibility;
    }

    private void SwitchVisibility()
    {
        if (TVSpawnerParent.switchedOff /*switchedOff*/)
            {
            if (enemySpawned)
            {
                skinnedMeshRenderer.enabled = false;
            }
                //switchedOff = false;
        }
        else
        {
            if (enemySpawned)
            {
                skinnedMeshRenderer.enabled = true;
            }
                //switchedOff = true;
        }
    }

    public void ActivateSadakoSkin(int i)
    {
        skinnedMeshRenderer = sadakoSkins[i].GetComponent<SkinnedMeshRenderer>();
        
            sadakoSkins[i].SetActive(true);
        if (/*switchedOff*/TVSpawnerParent.switchedOff)
        {
            skinnedMeshRenderer.enabled = false;
        }
        enemySpawned = true;
    }

    public void Attack()
    {
        TVSpawnerParent.TargetDamageDealt();
        // play particle effect
        StartCoroutine(DestroySelf());
        //DestroySelf();

    }

    public void SpawnEnemy()
    {
        TVSpawner.SpawnSadakoEnemy();
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(1.15f);
        Destroy(this.gameObject);
        Instantiate(explosionVFX, new Vector3(transform.position.x, transform.position.y + 1.1f, transform.position.z), Quaternion.identity);
    }

}
