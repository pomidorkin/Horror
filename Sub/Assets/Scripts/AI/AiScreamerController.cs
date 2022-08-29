using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiScreamerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] JumpScare jumpScare;

    private void OnEnable()
    {
        jumpScare.OnJumpScareEvent += PlayJumpscareANimAndSound;
    }

    private void OnDisable()
    {
        jumpScare.OnJumpScareEvent -= PlayJumpscareANimAndSound;
    }

    private void PlayJumpscareANimAndSound(object source, JumpScare.JumpScareEventArgs args)
    {
        PlayJumpscareAnim();
        // TODO: Play scary sound
    }

    private void PlayJumpscareAnim()
    {
        animator.Play("Zombie Headbutt");
    }
}
