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
        //sqrdJumpscareActivationDistance = (agent.navMeshAgent.stoppingDistance * agent.navMeshAgent.stoppingDistance) + 2f;
        sqrdJumpscareActivationDistance = agent.navMeshAgent.stoppingDistance + .5f;
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

            float distance = Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position);
            if (sqrdJumpscareActivationDistance >= distance)
            {
                agent.jumpScare.CameraLookControllerActivated(agent.targetLookPosition); // Commented out for testing
                agent.followObject.GetComponent<PlayerManager>().SetPlayerScared(true);
            }
                
            else if (sqrdJumpscareActivationDistance < distance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {

                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }
            
            timer = agent.config.maxTime;
        }
    }


}