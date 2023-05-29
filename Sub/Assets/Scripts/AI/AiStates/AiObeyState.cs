using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiObeyState : AiState
{
    private float timer = 0.0f;
    public void Enter(AiAgent agent)
    {
        if (agent.enemyType != AiAgent.EnemyType.Wanderer)
        {
            agent.navMeshAgent.speed = agent.defaultSpeed;
        }
        if (agent.sensor.enabled)
        {
            agent.sensor.enabled = false;
        }
        agent.navMeshAgent.destination = agent.tagertPosition;
        agent.navMeshAgent.speed = 5;
        agent.navMeshAgent.isStopped = false;
    }
    public void Update(AiAgent agent)
    {
        if (!agent.enabled)
        {

            return;
        }
        //throw new System.NotImplementedException();
        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {

            agent.navMeshAgent.destination = agent.tagertPosition;
        }

        if (timer < 0.0f)
        {
            /*Vector3 direction = (agent.followObject.position - agent.navMeshAgent.destination);
            direction.y = 0;*/
            float distance = Vector3.Distance(agent.tagertPosition, agent.gameObject.transform.position);
            if (0.1f >= distance)
            {
                agent.navMeshAgent.speed = 0;
                agent.navMeshAgent.isStopped = true;
                agent.stateMachine.ChangeState(AiStateId.Idle);
            }

            timer = agent.config.maxTime;
        }
    }

    public void Exit(AiAgent agent)
    {
        //
    }

    public AiStateId GetId()
    {
        return AiStateId.Obey;
    }

    
}
