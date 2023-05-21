using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class NoiseMeter : MonoBehaviour
{
    public bool noiseMeterEnabled = true;
    private float noiseValue = 0f;
    [SerializeField] float maxNoiseValue = 100f;
    [SerializeField] float noiseIncrementValue = 25f;
    [SerializeField] float decrementValue = 1f;
    [SerializeField] Slider noiseSlider;

    public delegate void NoiceMadeAction();
    public event NoiceMadeAction OnVoiceMade;

    private void Start()
    {
        noiseSlider.value = 0;
    }

    public void NoiseMade()
    {
        if ((noiseValue + noiseIncrementValue) < maxNoiseValue && noiseMeterEnabled)
        {
            noiseValue += noiseIncrementValue;
        }
        else
        {
            noiseValue = maxNoiseValue;
            noiseSlider.value = noiseValue;
            OnVoiceMade();
        }
    }

    private void Update()
    {
        if (noiseValue > 0 && noiseMeterEnabled)
        {
            noiseValue -= decrementValue * Time.deltaTime;
            noiseSlider.value = noiseValue;
        }
    }
}