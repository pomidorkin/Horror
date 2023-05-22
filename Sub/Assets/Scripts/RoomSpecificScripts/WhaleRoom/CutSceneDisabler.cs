using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDisabler : MonoBehaviour
{
    [SerializeField] GameObject objectToDisable;
    [SerializeField] GameObject samurai;
    [SerializeField] NoiseMeter noiseMeter;
    [SerializeField] GameObject noiseSlider;
    [SerializeField] PlayerGeishaController playerGeishaController;
    private void OnEnable()
    {
        samurai.SetActive(true);
        playerGeishaController.SetBellPicked(true);
        noiseSlider.SetActive(true);
        objectToDisable.SetActive(false);
        noiseMeter.noiseMeterEnabled = true;
        this.gameObject.SetActive(false);
    }
}
