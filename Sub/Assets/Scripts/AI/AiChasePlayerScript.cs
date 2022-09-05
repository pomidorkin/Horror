using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerScript : AiState
{
    private float timer = 0.0f;
    private float sqrdJumpscareActivationDistance;
    public void Enter(AiAgent agent)
    {
        sqrdJumpscareActivationDistance = (agent.navMeshAgent.stoppingDistance * agent.navMeshAgent.stoppingDistance) + 2f;
    }

    public void Exit(AiAgent agent)
    {
    }

    public AiStateId GetId()
    {
        return AiStateId.ChasePlayer;
    }

    public void Update(AiAgent agent)
    {
        Debug.Log("AiChasePlayerScript");
        if (!agent.enabled)
        {
            
            return;
        }

        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {
            
            agent.navMeshAgent.destination = agent.followObject.position;
        }
        if (timer < 0.0f)
        {
            
            Vector3 direction = (agent.followObject.position - agent.navMeshAgent.destination);
            direction.y = 0;
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    
                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }
            else if (sqrdJumpscareActivationDistance > (agent.gameObject.transform.position - agent.followObject.position).sqrMagnitude)
            {
                // Play anim; Change State to JumpScare; Disable Player Movement etc...
                agent.jumpScare.JumpScareActivated(agent.targetLookPosition);
            }
            timer = agent.config.maxTime;

        }
    }


}