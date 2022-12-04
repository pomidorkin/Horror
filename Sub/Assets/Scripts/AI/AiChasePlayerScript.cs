using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerScript : AiState
{
    private float timer = 0.0f;
    private float sqrdJumpscareActivationDistance;
    //private bool isStopped = false;
    public void Enter(AiAgent agent)
    {
        agent.navMeshAgent.speed = agent.defaultSpeed;
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
                agent.navMeshAgent.speed = 0;
                agent.navMeshAgent.isStopped = true;
                //agent.navMeshAgent.destination = agent.gameObject.transform.position; // TEST FOR STOPPING
                //agent.navMeshAgent.isStopped = true;// TEST FOR STOPPING
                //agent.navMeshAgent.enabled = false;
                

                agent.jumpScare.CameraLookControllerActivated(agent.targetLookPosition, agent.gameObject);
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