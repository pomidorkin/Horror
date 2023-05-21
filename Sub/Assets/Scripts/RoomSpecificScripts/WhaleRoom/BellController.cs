using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : MonoBehaviour
{
    [SerializeField] NoiseMeter noiseMeter;
    [SerializeField] Animator animator;

    private void OnEnable()
    {
        noiseMeter.OnVoiceMade += PlayRingAnim;
    }

    private void OnDisable()
    {
        noiseMeter.OnVoiceMade -= PlayRingAnim;
    }

    private void PlayRingAnim()
    {
        animator.Play("Ring");
    }
}
