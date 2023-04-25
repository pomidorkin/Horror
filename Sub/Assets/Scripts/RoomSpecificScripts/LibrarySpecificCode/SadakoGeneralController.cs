using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadakoGeneralController : MonoBehaviour
{
    private TVSpawnerParent TVSpawnerParent;
    [SerializeField] GameObject[] sadakoSkins;
    [SerializeField] TVSpawner TVSpawner;
    [SerializeField] GameObject explosionVFX;

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
