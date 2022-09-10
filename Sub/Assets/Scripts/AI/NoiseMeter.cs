using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMeter : MonoBehaviour
{
    public bool noiseMeterEnabled = false;
    private float noiseValue = 0f;
    private float currentNoiseValue = 0f;
    [SerializeField] float maxNoiseValue = 100f;
    [SerializeField] float noiseIncrementValue = 25f;
    [SerializeField] float decrementValue = 5f;

    [SerializeField] float decrementSpeed = 1f;


    // TEST
    float timeInterpolator = 0f;

    private void Start()
    {
        noiseMeterEnabled = true;
    }

    public void NoiseMade()
    {
        noiseValue = currentNoiseValue + noiseIncrementValue;
        Debug.Log("noiseValue: " + noiseValue);
        timeInterpolator = 0f;
    }

    private void Update()
    {

        if (noiseValue > 0f)
        {
            if (timeInterpolator < 1f)
            {
                currentNoiseValue = Mathf.Lerp(noiseValue, 0f, timeInterpolator);
                timeInterpolator += (1f / (noiseValue / decrementValue)) * Time.deltaTime;
            }
            else
            {
                timeInterpolator = 0f;
                noiseValue = 0f;
                currentNoiseValue = 0f;
            }
            Debug.Log(currentNoiseValue);
        }
    }
}