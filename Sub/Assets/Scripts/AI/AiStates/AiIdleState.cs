using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiIdleState : AiState
{

    public AiStateId GetId()
    {
        return AiStateId.Idle;
    }
    public void Enter(AiAgent agent)
    {
        Debug.Log("Ai Idle State");
        agent.animator.SetTrigger("Idle");
    }

    public void Exit(AiAgent agent)
    {
    }

    public void Update(AiAgent agent)
    {
        /*Vector3 followObjectDirection = agent.followObject.position - agent.transform.position;
        if (followObjectDirection.magnitude > agent.config.maxSightDistance)
        {
            return;
        }

        Vector3 agentDirection = agent.transform.forward;
        followObjectDirection.Normalize();
        float dotProduct = Vector3.Dot(followObjectDirection, agentDirection);
        if (dotProduct > 0.0f)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }*/
    }
}