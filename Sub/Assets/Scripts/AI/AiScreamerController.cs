using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiScreamerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] JumpScare jumpScare;
    [SerializeField] Transform jumpscarePositionOnPlayer;

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
        if (GetComponent<AiAgent>().enemyType == AiAgent.EnemyType.Crabwalk)
        {
            GetComponent<AiAgent>().characterModel.transform.rotation = Quaternion.Euler(0,-90,0);
        }
        animator.SetTrigger("JumpscareActivate");
        //transform.position = jumpscarePositionOnPlayer.position;
    }
}