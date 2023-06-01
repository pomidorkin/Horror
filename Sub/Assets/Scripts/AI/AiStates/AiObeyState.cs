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
        agent.navMeshAgent.destination = agent.GetTargetPosition();
        //agent.navMeshAgent.speed = 5;
        agent.navMeshAgent.speed = agent.defaultSpeed;
        agent.navMeshAgent.isStopped = false;
        //agent.animator.SetTrigger("Walk");
    }
    public void Update(AiAgent agent)
    {
        //Debug.Log("agent.navMeshAgent.destination: " + agent.navMeshAgent.destination);
        if (!agent.enabled)
        {

            return;
        }
        //throw new System.NotImplementedException();
        timer -= Time.deltaTime;
        if (!agent.navMeshAgent.hasPath)
        {

            agent.navMeshAgent.destination = agent.GetTargetPosition();
        }

        if (timer < 0.0f)
        {
            agent.navMeshAgent.destination = agent.GetTargetPosition();
            Vector3 direction = (agent.GetTargetPosition() - agent.navMeshAgent.destination);
            direction.y = 0;
            float distance = Vector3.Distance(agent.GetTargetPosition(), agent.gameObject.transform.position);
            //Debug.Log("distance: " + distance);
            if (2f >= distance)
            {
                agent.navMeshAgent.speed = 0;
                agent.navMeshAgent.isStopped = true;
                //Debug.Log("Obey Target Reached");
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
