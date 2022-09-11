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
            
            if (sqrdJumpscareActivationDistance >= Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position))
            {
                agent.jumpScare.JumpScareActivated(agent.targetLookPosition); // Commented out for testing
            }
            else if (sqrdJumpscareActivationDistance < Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position))
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {

                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }
            //if (Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position) > (sqrdJumpscareActivationDistance - 2f))
            //if ((sqrdJumpscareActivationDistance) < Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position))
            /*if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    
                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }*/
            
            timer = agent.config.maxTime;

            Debug.Log("Vector3.Distance(agent.followObject.position, agent.navMeshAgent.destination); " + Vector3.Distance(agent.followObject.position, agent.gameObject.transform.position) + " direction.sqrMagnitude: " + direction.sqrMagnitude + " (sqrdJumpscareActivationDistance - 2f): " + (sqrdJumpscareActivationDistance - 2f) + " sqrdJumpscareActivationDistance: " + sqrdJumpscareActivationDistance);

        }
    }


}