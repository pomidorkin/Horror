using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTVMonsterController : MonoBehaviour
{
    [SerializeField] AiAgent tvMonsterAiAgent;
    [SerializeField] private Transform cam;
    private bool raycastAllowed = true;
    private bool active;
    RaycastHit hit;
    [SerializeField] private float raycastDistance = 30f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] GameObject laserParticle;
    [SerializeField] PlayerMovement playerMovement;
    private PlyerInputActions playerInputActions;
    private bool setDestinationMode = true;
    private bool remoteControlPicked = true;
    private bool firstObey = true;
    [SerializeField] Light remoteControlLight;
    [SerializeField] Color colorRed;
    [SerializeField] Color colorGreen;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] RemoteControlAnimationController remoteControlAnimationController;
    private float timer = 0;
    private bool commandAllowed = false;
    private void OnEnable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += Reset;
        playerInputActions = playerMovement.GetPlayerInputActions();
        playerInputActions.Player.Interaction.performed += ChangeRemoteControlMode;
        tvMonsterAiAgent.animator.SetTrigger("Walk");
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.DrawRay(cam.position, cam.transform.TransformDirection(Vector3.forward) * 5);
    }*/
    private void OnDisable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= Reset;
        playerInputActions.Player.Interaction.performed -= ChangeRemoteControlMode;
    }

    private void Reset()
    {
        setDestinationMode = true; // true for testing, should be false in production
        remoteControlPicked = true;
        firstObey = true;
        remoteControlLight.color = colorGreen;
        if (tvMonsterAiAgent.stateMachine.currentState != AiStateId.Obey || tvMonsterAiAgent.stateMachine.currentState != AiStateId.ChasePlayer)
        {
            tvMonsterAiAgent.animator.SetTrigger("Walk");
        }
        //tvMonsterAiAgent.sensor.enabled = true;
    }

    private void Update()
    {
        if (timer < 2f && !commandAllowed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            commandAllowed = true;
        }
    }

    private void ChangeRemoteControlMode(InputAction.CallbackContext obj)
    {
        if (remoteControlPicked)
        {
                setDestinationMode = !setDestinationMode;
                if (setDestinationMode)
                {
                    remoteControlLight.color = colorGreen;
                }
                else
                {
                    remoteControlLight.color = colorRed;
                }
            
        }
    }

    public void MouseClickedHandler()
    {

        if (commandAllowed)
        {
            commandAllowed = false;
            remoteControlAnimationController.PlayITweenAnim();
            if (remoteControlPicked)
            {
                if (setDestinationMode)
                {
                    tvMonsterAiAgent.navMeshAgent.isStopped = false;
                    //tvMonsterAiAgent.animator.SetTrigger("Walk");
                    Debug.Log("MouseClickedHandler");
                    SetFollowOrder();
                }
                else
                {
                    //tvMonsterAiAgent.navMeshAgent.isStopped = true;
                    tvMonsterAiAgent.stateMachine.ChangeState(AiStateId.ObeyAttackState);
                    //tvMonsterAiAgent.animator.SetTrigger("Attack");
                }
            }
        }
    }

    public void SetFollowOrder()
    {
        Debug.Log("SetFollowOrder");
        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, raycastDistance, groundLayer))
        {
            laserParticle.SetActive(true);
            SetNewFollowDestination();
            Debug.Log("Raycast hit position: " + hit.point.x);
            StartCoroutine(DisableLaserCoroutine());
        }
    }

    private IEnumerator DisableLaserCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        laserParticle.SetActive(false);
    }

    private void SetNewFollowDestination()
    {
        tvMonsterAiAgent.SetTargetPosition(new Vector3(hit.point.x, 0, hit.point.z));
        if (tvMonsterAiAgent.stateMachine.currentState != AiStateId.Obey)
        {
            //tvMonsterAiAgent.animator.SetTrigger("Walk");
            if (firstObey)
            {
                firstObey = false;
            }
            else
            {
                if (tvMonsterAiAgent.stateMachine.currentState != AiStateId.Obey)
                {
                    tvMonsterAiAgent.animator.SetTrigger("Walk");
                }
            }
            tvMonsterAiAgent.stateMachine.ChangeState(AiStateId.Obey);
        }
    }
}
