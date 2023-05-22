using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SamuraiController : MonoBehaviour
{
    private float speed = 2f;
    [SerializeField] Transform[] targetPositions;
    [SerializeField] Transform playerPosition;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] NoiseMeter noiseMeter;
    [SerializeField] WhalseSceneRespawnManager whalseSceneRespawnManager;
    private bool canMove = true;
    private Animator animator;
    private bool isAttacking = false;
    private int lastRnd = 0;
    [SerializeField] BoxCollider attackCollider;
    [SerializeField] float couchSpeed = 5.4f;
    [SerializeField] float runSpeed = 9.2f;
    // Start is called before the first frame update

    private void OnEnable()
    {
        noiseMeter.OnVoiceMade += SetPlayerTarget;
        navMeshAgent.speed = couchSpeed;
    }

    private void OnDisable()
    {
        noiseMeter.OnVoiceMade -= SetPlayerTarget;
    }

    private void SetPlayerTarget()
    {
        if (canMove)
        {
            navMeshAgent.SetDestination(new Vector3(playerPosition.position.x, 0, playerPosition.position.z));
            animator.SetTrigger("NoticedPlayer");
            navMeshAgent.speed = runSpeed;
        }
        
    }

    void Start()
    {
        navMeshAgent.SetDestination(targetPositions[0].position);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (navMeshAgent.remainingDistance > 3.2f && canMove)
        {
            Debug.Log("remainingDistance: " + navMeshAgent.remainingDistance);
        }
        else
        {
            canMove = false;
            if (!isAttacking)
            {
                Attack();
            }
        }
        if (!canMove && !isAttacking)
        {
            canMove = true;
        }
    }

    public void DisableAttackCollider()
    {
        attackCollider.enabled = false;
    }
    public void EnableAttackCollider()
    {
        attackCollider.enabled = true;
    }

    public void EnableMoving()
    {
        DisableAttackCollider();
        canMove = true;
        isAttacking = false;
        int rnd;
        do 
        {
            rnd = Random.Range(0, targetPositions.Length);
        } while (lastRnd == rnd) ;
        navMeshAgent.SetDestination(targetPositions[rnd].position);
    }

    private void Attack()
    {
        navMeshAgent.speed = couchSpeed;
        isAttacking = true;
        int randomNumber = Random.Range(1, 3);
        animator.SetTrigger("Attack_" + randomNumber);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            whalseSceneRespawnManager.TriggerRespawnEvent();
        }
    }
}
