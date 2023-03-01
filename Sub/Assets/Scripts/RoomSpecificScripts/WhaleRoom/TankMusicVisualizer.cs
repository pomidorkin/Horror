using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMusicVisualizer : MonoBehaviour
{
    [SerializeField] AudioVisualizerManager audioVisualizerManager;
    [SerializeField] ParticleSystem cannonShotParticle;
    private Animator animator;
    private void OnEnable()
    {
        audioVisualizerManager.OnPeakReachedAction += PeakReachedHandler;
        animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        audioVisualizerManager.OnPeakReachedAction -= PeakReachedHandler;
    }

    private void PeakReachedHandler()
    {
        animator.Play("ShootAnimation");
        //cannonShotParticle.gameObject.SetActive(true);
        StartCoroutine(PlayShotParticleSystem());
    }

    private IEnumerator PlayShotParticleSystem()
    {
        cannonShotParticle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.33f);
        cannonShotParticle.gameObject.SetActive(false);
    }
}
