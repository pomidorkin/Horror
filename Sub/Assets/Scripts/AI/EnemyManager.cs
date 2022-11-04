using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    //private Vector3 initialSpawnPosition;
    private Vector3 initialSpawnRotation;
    [SerializeField ]private NavMeshAgent navMeshAgent;
    [SerializeField] private RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform[] respawnPositions;
    [SerializeField] AiSensor aiSensor;

    private void OnEnable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += RespawnEnemy;

        navMeshAgent.enabled = false;
        initialSpawnRotation = enemy.transform.eulerAngles;
        //if (enemy.transform.eulerAngles.y > 175)
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
        aiSensor.EnableSecondEnemy();
        Debug.Log("EnemyIsBeingRespawned");
        navMeshAgent.enabled = false;
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
        //enemy.transform.position = initialSpawnPosition;
        enemy.transform.eulerAngles = initialSpawnRotation;
        navMeshAgent.enabled = true;
    }
}
