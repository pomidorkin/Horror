using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVHeadController : MonoBehaviour
{
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] public AudioVisualizerManager audioVisualizerManager;
    [SerializeField] GameObject dictatorTV;
    [SerializeField] GameObject noiseTV;
    private bool isObeying = false;
    private bool switched = false;
    private void OnEnable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += Reset;
        audioVisualizerManager.OnPeakReachedAction += SwitchTV;
    }
    private void OnDisable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= Reset;
        audioVisualizerManager.OnPeakReachedAction -= SwitchTV;
    }

    private void SwitchTV()
    {
        if (!isObeying)
        {
            if (switched)
            {
                switched = false;
                dictatorTV.SetActive(true);
                noiseTV.SetActive(false);
            }
            else
            {
                switched = true;
                dictatorTV.SetActive(false);
                noiseTV.SetActive(true);
            }
        }
    }

    private void Reset()
    {
        isObeying = false;
        dictatorTV.SetActive(true);
        noiseTV.SetActive(false);
    }
}
