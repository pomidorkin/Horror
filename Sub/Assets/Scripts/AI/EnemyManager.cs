using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] bool isWanderer = false;
    private Vector3 initialSpawnPosition;
    private Vector3 initialSpawnRotation;
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform[] respawnPositions;
    [SerializeField] AiSensor aiSensor;
    [SerializeField] AiAgent agent;

    private void OnEnable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += RespawnEnemy;

        navMeshAgent.enabled = false;
        initialSpawnRotation = enemy.transform.eulerAngles;
        initialSpawnPosition = enemy.transform.position;
        //if (enemy.transform.eulerAngles.y > 175)
        if (!isWanderer)
        {
            if (initialSpawnRotation.y > 175)
            {
                // Left enemy
                enemy.transform.position = respawnPositions[1].position;
            }
            else
            {
                // Right Enemy
                enemy.transform.position = respawnPositions[0].position;
            }
        }
        else
        {
            enemy.transform.position = initialSpawnPosition;
        }
        
        navMeshAgent.enabled = true;
    }

    private void OnDisable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= RespawnEnemy;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("enemy.transform.position: " + enemy.transform.position);
        //initialSpawnPosition = enemy.transform.position;
        //initialSpawnRotation = enemy.transform.eulerAngles;
        //navMeshAgent = enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnEnemy()
    {
        Debug.Log("EnemyIsBeingRespawned");
        navMeshAgent.enabled = false;
        if (!isWanderer)
        {
            aiSensor.EnableSecondEnemy();
            if (enemy.transform.eulerAngles.y > 175)
            {
                // Left enemy
                enemy.transform.position = respawnPositions[1].position;
            }
            else
            {
                // Right Enemy
                enemy.transform.position = respawnPositions[0].position;
            }
            enemy.transform.eulerAngles = initialSpawnRotation;
            navMeshAgent.enabled = true;
        }
        else
        {
            enemy.transform.position = initialSpawnPosition;
            enemy.transform.eulerAngles = initialSpawnRotation;
            navMeshAgent.enabled = true;
            agent.noticedPlayer = false;
            agent.sensor.enabled = true;
            agent.animator.SetBool("Follow", false);
            agent.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
            if (agent.stateMachine.currentState != AiStateId.Wander)
            {
                agent.stateMachine.ChangeState(AiStateId.Wander);
            }
        }
        //enemy.transform.position = initialSpawnPosition;
        
    }
}
