using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiObeyAttackState : AiState
{
    private bool attackTriggered = false;
    private float timer = 0f;
    public void Enter(AiAgent agent)
    {
        agent.navMeshAgent.isStopped = true;
        //agent.navMeshAgent.destination = agent.transform.position;
        agent.animator.SetTrigger("Attack");
    }

    public void Update(AiAgent agent)
    {
        if (attackTriggered)
        {
            timer += Time.deltaTime;
            if (timer >= 3.0f)
            {
                timer = 0;
                //agent.animator.SetTrigger("Idle");
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }
        }

        
    }

    public void Exit(AiAgent agent)
    {
    }

    public AiStateId GetId()
    {
        return AiStateId.ObeyAttackState;
    }
    
}
