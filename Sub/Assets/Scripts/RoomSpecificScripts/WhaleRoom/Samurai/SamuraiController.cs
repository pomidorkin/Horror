using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamuraiController : MonoBehaviour
{
    private float speed = 2f;
    [SerializeField] Transform[] targetPositions;
    [SerializeField] Transform playerPosition;
    private Vector3 target;
    [SerializeField] NoiseMeter noiseMeter;
    private bool canMove = true;
    private Animator animator;
    private bool isAttacking = false;
    private int lastRnd = 0;
    // Start is called before the first frame update

    private void OnEnable()
    {
        noiseMeter.OnVoiceMade += SetPlayerTarget;
    }

    private void OnDisable()
    {
        noiseMeter.OnVoiceMade -= SetPlayerTarget;
    }

    private void SetPlayerTarget()
    {
        target = new Vector3(playerPosition.position.x, 0, playerPosition.position.z);
    }

    void Start()
    {
        target = targetPositions[0].position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target) > 2f && canMove)
        {
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            canMove = false;
            if (!isAttacking)
            {
                Attack();
            }
        }
    }

    public void EnableMoving()
    {
        canMove = true;
        isAttacking = false;
        int rnd;
        do 
        {
            rnd = Random.Range(0, targetPositions.Length);
        } while (lastRnd == rnd) ;
        target = targetPositions[rnd].position;
    }

    private void Attack()
    {
        isAttacking = true;
        int randomNumber = Random.Range(1, 3);
        animator.SetTrigger("Attack_" + randomNumber);
    }
}
