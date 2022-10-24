using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindEnemy : MonoBehaviour
{
    [SerializeField] private NoiseMeter noiseMeter;
    [SerializeField] private Animator animator;
    private AiAgent aiAgent;

    private void Start()
    {
        aiAgent = this.GetComponent<AiAgent>();
    }

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
        if (!aiAgent.noticedPlayer)
        {
            if (aiAgent.enemyType == AiAgent.EnemyType.Crabwalk)
            {
                aiAgent.stateMachine.ChangeState(AiStateId.Transition);
            }
            else if (aiAgent.enemyType == AiAgent.EnemyType.EvilGirl)
            {
                GetComponent<SpawnEffect>().DoFade(0f, 2f, 2f);
            }
            else
            {
                aiAgent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
            animator.SetBool("Follow", true);
            aiAgent.noticedPlayer = true;
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
