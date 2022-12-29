using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererEventHandler : MonoBehaviour
{
    [SerializeField] EventsBroadcaster eventsBroadcaster;
    [SerializeField] AiAgent agent;
    [SerializeField] AiScreamerController aiScreamerController;

    private void OnEnable()
    {
        eventsBroadcaster.OnHidePerformedAction += OnHidePerformedHandler;
    }

    private void OnDisable()
    {
        eventsBroadcaster.OnHidePerformedAction -= OnHidePerformedHandler;
    }

    private void OnHidePerformedHandler()
    {
        Debug.Log("OnHidePerformedHandler");
        agent.stateMachine.ChangeState(AiStateId.Wander);
        agent.noticedPlayer = false;

        aiScreamerController.gameObject.GetComponent<AiSensor>().enabled = true;
        aiScreamerController.animator.SetBool("Follow", false);
        aiScreamerController.animator.SetBool("Reset", true);
    }

}