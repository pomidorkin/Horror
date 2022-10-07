using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] TVSpawnerParent TVSpawnerParent;
    [SerializeField] Animator animator;
    [SerializeField] int targetHealth = 100;
    [SerializeField] int damageAmount = 5;

    private void OnEnable()
    {
        TVSpawnerParent.OnDamageDealt += myFunc;
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
            targetHealth -= damageAmount;
        }
        else
        {
            // Game lose logic
        }
        
    }
}
