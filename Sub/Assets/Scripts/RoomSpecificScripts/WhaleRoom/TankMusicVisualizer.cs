using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMusicVisualizer : MonoBehaviour
{
    private Animator animator;

    private AudioVisualizerManager audioVisualizerManager;
    private void OnEnable()
    {
        audioVisualizerManager = FindObjectOfType<AudioVisualizerManager>();
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
    }
}
