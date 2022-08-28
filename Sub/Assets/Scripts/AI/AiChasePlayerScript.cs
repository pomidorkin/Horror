using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerScript : AiState
{
    //Transform followObject;
    private float timer = 0.0f;
    public void Enter(AiAgent agent)
    {
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
            if (direction.sqrMagnitude > agent.config.maxDistance * agent.config.maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }
            /*else if (5f > agent.config.maxDistance * agent.config.maxDistance)
            {
                agent.jumpScare.JumpScareActivated(agent.transform);
            }*/
            else
            {
                agent.jumpScare.JumpScareActivated(agent.transform);
                // Play anim; Change State to JumpScare; Disable Player Movement etc...
            }
            timer = agent.config.maxTime;
        }
    }
}