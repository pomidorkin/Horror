using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalateaController : MonoBehaviour
{
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void StopMotion()
    {
        animator.SetTrigger("Stop");
    }

    public void EnableMotion()
    {
        animator.Play("catwalk");
    }
}
