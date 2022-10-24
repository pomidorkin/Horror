using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleIdex : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void Start()
    {
        SetRandomIddleAnimIndex();
    }

    public void SetRandomIddleAnimIndex()
    {
        animator.SetInteger("IdleAnimIndex", Random.RandomRange(0, 4));
        //animator.SetTrigger("Idle");
    }
}
