using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AiScreamerController : MonoBehaviour
{
    [SerializeField] public Animator animator;
    [SerializeField] CameraLookController jumpScare;
    [SerializeField] GameObject respawnManager;
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
        if (args.TriggerEnemy == this.gameObject)
        {
            PlayJumpscareAnim();
        }
        else
        {
            // If another enemy has played the jumpscare anim, but it's not me
            // For example, set to idle animation state
        }
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
        respawnManager.GetComponent<IRespawnManager>().PlayRespawnUIAnim();
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5);
        respawnManager.GetComponent<IRespawnManager>().Respawn(this);
    }
}