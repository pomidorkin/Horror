using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeishaInteractable : InteractionParent
{
    [SerializeField] GameObject cusScene;
    [SerializeField] GameObject bellObject;
    [SerializeField] NoiseMeter noiseMeter;
    [SerializeField] GameObject samurai;

    public override void ActivateInteractable()
    {
        cusScene.SetActive(true);
        bellObject.SetActive(false);
        samurai.SetActive(false);
        noiseMeter.noiseMeterEnabled = false;
        this.gameObject.SetActive(false);
    }
}
