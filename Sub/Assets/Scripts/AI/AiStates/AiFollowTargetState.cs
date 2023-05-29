using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiFollowTargetState : AiState
{
    private float timer = 0.0f;
    private float attackActivationDistance;

    public AiStateId GetId()
    {
        return AiStateId.FollowTarget;
    }

    public void Enter(AiAgent agent)
    {
        attackActivationDistance = Mathf.Sqrt(agent.navMeshAgent.stoppingDistance) + .7f;
    }

    public void Exit(AiAgent agent)
    {
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
            if (attackActivationDistance >= distance)
            {
                agent.stateMachine.ChangeState(AiStateId.Attack);
            }

            else if (attackActivationDistance < distance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {

                    agent.navMeshAgent.destination = agent.followObject.position;
                }
            }

            //Debug.Log("attackActivationDistance: " + attackActivationDistance + " distance: " + distance);

            timer = 1f;
        }
    }
}
