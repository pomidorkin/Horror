using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiWanderState : AiState
{
    // TODO: AiAgent shoud keep wander status: random or patroling
    // In addition, wandering animation and NavMeshAgent speed shoul be different from chasing speed & animation

    private int positionCounter = 0;
    public void Enter(AiAgent agent)
    {
        agent.navMeshAgent.speed = 0.5f;
        positionCounter = 0;
        // TODO: Somehow reset the target and movement anim
        agent.navMeshAgent.destination = agent.followPositions[positionCounter].position;
        agent.navMeshAgent.stoppingDistance = 0f;
        //positionCounter++;
    }

    public void Exit(AiAgent agent)
    {
        // TODO: Change value here when you decide which animation to use
        agent.SetSpeed(0.871f);
        agent.navMeshAgent.stoppingDistance = 2f;
    }

    public AiStateId GetId()
    {
        return AiStateId.Wander;
    }

    private Vector3 RandomNavSphere(Vector3 origin, float distance, LayerMask layerMask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navMeshHit;

        NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, layerMask);

        return navMeshHit.position;
    }

    public void Update(AiAgent agent)
    {
        if (!agent.enabled)
        {
            return;
        }
        DoWander(agent);
    }

    private void DoWander(AiAgent agent)
    {
        if (agent.wanderType == AiAgent.WanderType.Predetermined)
        {
            if (agent.navMeshAgent.remainingDistance < 0.1f /*|| !agent.navMeshAgent.hasPath*/)
            {
                if (positionCounter < agent.followPositions.Length)
                {
                    Debug.Log("positionCounter: " + positionCounter);
                    agent.navMeshAgent.destination = agent.followPositions[positionCounter].position;
                    positionCounter++;
                }
                else
                {
                    positionCounter = 0;
                    agent.navMeshAgent.destination = agent.followPositions[positionCounter].position;
                    positionCounter++;
                }

            }
            else if (!agent.navMeshAgent.hasPath)
            {
                agent.navMeshAgent.destination = agent.followPositions[positionCounter].position;
            }
        }
        else
        {
            if (agent.navMeshAgent.remainingDistance < 0.1f || !agent.navMeshAgent.hasPath)
            {

                // 10f is the area around ai in which a random position can be chosen.
                // TODO: Add this field to the config
                agent.navMeshAgent.destination = RandomNavSphere(agent.transform.position, 10.0f, NavMesh.AllAreas);
            }
        }
    }
}
