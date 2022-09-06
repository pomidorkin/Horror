using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiScreamerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] JumpScare jumpScare;
    //[SerializeField] Transform jumpscarePositionOnPlayer;

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
        AiAgent agent = GetComponent<AiAgent>();
        agent.stateMachine.ChangeState(AiStateId.Jumpscare);
        if (agent.enemyType == AiAgent.EnemyType.Crabwalk)
        {
            agent.modelRotator.transform.rotation = Quaternion.Euler(0,-90,0);
            //agent.characterModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        animator.SetTrigger("JumpscareActivate");
        //agent.characterModel.transform.position = jumpscarePositionOnPlayer.position;
        //transform.position = jumpscarePositionOnPlayer.position;
    }
}