using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThimblesParent : MonoBehaviour
{
    [SerializeField] GameObject thimblesGroup;
    [SerializeField] Transform[] senseiPositions;
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ThimblesController thimblesController;
    private int lastRnd;

    public void SetNewPosition()
    {
        int rnd;
        do
        {
            rnd = Random.Range(0, senseiPositions.Length);
        }
        while (rnd == lastRnd);
        lastRnd = rnd;
        thimblesGroup.transform.localPosition = senseiPositions[rnd].localPosition;        
        thimblesGroup.SetActive(true);
        StartCoroutine(DisableParticleSystem());
        thimblesController.ResetThimbles();
    }

    private IEnumerator DisableParticleSystem()
    {
        yield return new WaitForSeconds(3f);
        explosionParticle.gameObject.SetActive(false);
    }
}