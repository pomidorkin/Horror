using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class FMODBus : MonoBehaviour
{
    Bus bus;
    [SerializeField] [Range(-80f, 10f)]
    private float busVolume;

    private void Start()
    {
        bus = RuntimeManager.GetBus("bus:/Master");
    }

    private void Update()
    {
        // This value should be changed from the OnValueChanged event on the UI slider
        bus.setVolume(DecibelToLinear(busVolume));
    }

    private float DecibelToLinear(float dB)
    {
        float linear = Mathf.Pow(10f, dB / 20f);
        return linear;
    }
}
