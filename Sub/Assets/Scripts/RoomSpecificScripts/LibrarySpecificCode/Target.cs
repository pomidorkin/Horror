using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] TVSpawnerParent TVSpawnerParent;
    [SerializeField] Animator animator;
    [SerializeField] int targetHealth = 100;
    [SerializeField] int damageAmount = 15;
    [SerializeField] LibrarySceneRespawnManager respawnManager;
    [SerializeField] Slider targetHealthSlider;

    private void OnEnable()
    {
        TVSpawnerParent.OnDamageDealt += myFunc;
        targetHealthSlider.value = targetHealthSlider.maxValue;
    }
    private void OnDisable()
    {
        TVSpawnerParent.OnDamageDealt -= myFunc;
    }

    private void myFunc()
    {
        // TODO: Play anim
        animator.Play("TargetDamageAnimation");
        DealDamage(damageAmount);
        Debug.Log(targetHealth);
    }

    public void DealDamage(int value)
    {
        if ((targetHealth - damageAmount) > 0)
        {
            Debug.Log("(targetHealth / 100): " + (float)(targetHealth / 100f));
            targetHealth -= damageAmount;
            targetHealthSlider.value = (float)(targetHealth / 100f);
        }
        else
        {
            targetHealth = 100;
            respawnManager.Respawn();
            targetHealthSlider.value = targetHealthSlider.maxValue;
        }
        
    }
}
