using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhaleController : MonoBehaviour
{
    [SerializeField] Slider whaleHealthSlider;
    [SerializeField] private float decrementSpeed = 1.0f;
    [SerializeField] WhalseSceneRespawnManager whalseSceneRespawnManager;
    private float step = 0;
    private float whaleMaxHealth = 1000;
    private float whaleCurrentHealth;
    private float healthDecrementValue = 20;
    private bool receivingDamage = true;
    // Start is called before the first frame update
    void Start()
    {
        whaleCurrentHealth = whaleMaxHealth;
        whaleHealthSlider.value = whaleHealthSlider.maxValue;
    }
    // Update is called once per frame
    void Update()
    {
        if (receivingDamage)
        {
            step += Time.deltaTime;
            if (step > decrementSpeed)
            {
                DecreaseWhaleHealth();
                step = 0;
            }
        }
    }

    private void DecreaseWhaleHealth()
    {
        if ((whaleCurrentHealth - healthDecrementValue) > 0)
        {
            whaleCurrentHealth -= healthDecrementValue;
            whaleHealthSlider.value = (100 / whaleMaxHealth) * whaleCurrentHealth;
        }
        else
        {
            WhaleDie();
        }
    }

    private void WhaleDie()
    {
        whaleCurrentHealth = whaleMaxHealth;
        whaleHealthSlider.value = whaleHealthSlider.maxValue;
        Respawn();
    }

    public void DamageReceived(float damageValue)
    {
        whaleCurrentHealth -= damageValue;
        if ((whaleCurrentHealth - healthDecrementValue) <= 0)
        {
            WhaleDie();
        }
    }

    private void Respawn()
    {
        whalseSceneRespawnManager.TriggerRespawnEvent();

    }
}
