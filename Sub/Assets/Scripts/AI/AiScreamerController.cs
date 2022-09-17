using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiScreamerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CameraLookController jumpScare;
    //[SerializeField] Transform jumpscarePositionOnPlayer;

    private void OnEnable()
    {
        jumpScare.OnCameraLookControllerEvent += PlayJumpscareANimAndSound;
    }

    private void OnDisable()
    {
        jumpScare.OnCameraLookControllerEvent -= PlayJumpscareANimAndSound;
    }

    private void PlayJumpscareANimAndSound(object source, CameraLookController.CameraLookControllerEventArgs args)
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
        }
        animator.SetTrigger("JumpscareActivate");
    }
}