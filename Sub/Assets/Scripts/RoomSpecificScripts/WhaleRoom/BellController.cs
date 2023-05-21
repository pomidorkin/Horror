using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellController : MonoBehaviour
{
    [SerializeField] NoiseMeter noiseMeter;
    [SerializeField] Animator animator;
    private bool animIsPlaying = false;

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
        Debug.Log("PlayRingAnim");
        //Debug.Log("animIsPlaying: " + animIsPlaying);
        if (!animIsPlaying)
        {
            animIsPlaying = true;
            animator.Play("Ring");
            StartCoroutine(SetAnimFinished());
        }
    }

    private IEnumerator SetAnimFinished()
    {
        yield return new WaitForSeconds(2f);
        animIsPlaying = false;
    }
}
