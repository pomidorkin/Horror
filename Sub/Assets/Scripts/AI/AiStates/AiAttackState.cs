using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackState : AiState
{
    public AiStateId GetId()
    {
        return AiStateId.Attack;
    }

    public void Enter(AiAgent agent)
    {
        agent.GetComponent<Animator>().SetBool("IsAttacking", true);
    }

    public void Exit(AiAgent agent)
    {
    }

    public void Update(AiAgent agent)
    {
    }
}
