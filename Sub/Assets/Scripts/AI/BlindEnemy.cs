using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    [SerializeField] private NoiseMeter noiseMeter;
    [SerializeField] private Animator animator;

    private void OnEnable()
    {
        noiseMeter.OnVoiceMade += OnVoiceMadeHandler;
    }

    private void OnDisable()
    {
        noiseMeter.OnVoiceMade -= OnVoiceMadeHandler;
    }

    private void OnVoiceMadeHandler()
    {
        Debug.Log("I noticed the player");
        if (!this.GetComponent<AiAgent>().noticedPlayer)
        {
            if (this.GetComponent<AiAgent>().enemyType == AiAgent.EnemyType.Crabwalk)
            {
                this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.Transition);
            }
            else if (this.GetComponent<AiAgent>().enemyType == AiAgent.EnemyType.EvilGirl)
            {
                GetComponent<SpawnEffect>().DoFade(0f, 2f, 2f);
            }
            else
            {
                this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
            animator.SetBool("Follow", true);
            this.GetComponent<AiAgent>().noticedPlayer = true;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
