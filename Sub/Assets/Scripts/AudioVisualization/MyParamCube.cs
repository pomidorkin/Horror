using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParamCube : MonoBehaviour
{
    private PlayerActions playerActions;
    private Door myChildDoor;
    [SerializeField] bool checker = false;
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

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
        myChildDoor = GetComponentInChildren<Door>();
    }

    private void PeakReachedHandler()
    {
        if (!checker)
        {
            if (playerActions.lastLookedAtObject != myChildDoor.gameObject)
            {
                animator.Play("SlammAnimation");
            }
        }
        else
        {
            animator.Play("SlammAnimation");
        }
        
    }

    public void SlamAnimationPlayed()
    {
        if (checker)
        {
            audioVisualizerManager.RaiseDoorSlammedEvent();
        }
    }
}