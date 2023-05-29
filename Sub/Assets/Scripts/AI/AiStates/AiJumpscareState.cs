using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiJumpscareState : AiState
{
    public void Enter(AiAgent agent)
    {
    }

    public void Exit(AiAgent agent)
    {
    }

    public AiStateId GetId()
    {
        return AiStateId.Jumpscare;
    }

    public void Update(AiAgent agent)
    {

        agent.characterModel.transform.LookAt(new Vector3(agent.eyesForNpc.position.x, 0, agent.eyesForNpc.position.z));
    }
}
