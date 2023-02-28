using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyParamCube : MonoBehaviour
{
    [SerializeField] [Range(0, 7)] int band = 0;
    [SerializeField] [Range(0f, 10f)] float animTriggerValue = 1.6f;
    private PlayerActions playerActions;
    private Door myChildDoor;
    [SerializeField] bool checker = false;
    private Animator animator;
    /*private GameManagerScript gameManager;
    float elapsedTime;
    float timeLimit = 0.1f;*/

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
        //gameManager = FindObjectOfType<GameManagerScript>();
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