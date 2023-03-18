using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalateaController : MonoBehaviour
{
    private bool stop = false;
    private Animator animator;
    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void StopMotion()
    {
        animator.SetBool("Stop", true);
    }

    public void EnableMotion()
    {
        animator.SetBool("Stop", false);
    }

    public bool IsStopped()
    {
        return stop;
    }
}
