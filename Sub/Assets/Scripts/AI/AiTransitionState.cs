using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiTransitionState : AiState
{
    public void Enter(AiAgent agent)
    {
        
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public AiStateId GetId()
    {
        return AiStateId.Transition;
    }

    public void Update(AiAgent agent)
    {
        Debug.Log("AiTransitionState");
        if (agent.transitionAnimationCompleted)
        {
            agent.stateMachine.ChangeState(AiStateId.ChasePlayer);
        }
    }
}
