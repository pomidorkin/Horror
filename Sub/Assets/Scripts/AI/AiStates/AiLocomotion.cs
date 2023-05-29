using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    NavMeshAgent agent;
    [SerializeField] Animator animator;
    private bool following = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (agent.hasPath)
        {
            if (!following)
            {
                //animator.SetFloat("Speed", /*agent.velocity.magnitude*/ agent.desiredVelocity.magnitude);

                //animator.SetBool("Follow", true);
                //ollowing = true;
            }
        }
        else
        {
            //animator.SetFloat("Speed", 0);
            //animator.SetBool("Follow", false);
            //following = false;
        }
    }
}