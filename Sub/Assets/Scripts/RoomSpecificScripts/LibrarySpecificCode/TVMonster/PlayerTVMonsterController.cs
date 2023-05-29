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
    private void OnEnable()
    {
        playerInputActions = playerMovement.GetPlayerInputActions();
        playerInputActions.Player.Interaction.performed += ChangeRemoteControlMode;
    }
    private void OnDisable()
    {
        playerInputActions.Player.Interaction.performed -= ChangeRemoteControlMode;
    }

    private void ChangeRemoteControlMode(InputAction.CallbackContext obj)
    {
        if (remoteControlPicked)
        {
            setDestinationMode = !setDestinationMode;
        }
    }

    public void MouseClickedHandler()
    {
        if (remoteControlPicked)
        {
            if (setDestinationMode)
            {
                SetFollowOrder();
            }
            else
            {
                // Trigger Attack
                Debug.Log("Attacking");
            }
        }
    }

    public void SetFollowOrder()
    {
        if (raycastAllowed)
        {
            active = Physics.Raycast(cam.position, cam.transform.TransformDirection(Vector3.forward), out hit, raycastDistance);
        }
        if (hit.collider != null)
        {
            if (hit.transform.gameObject.layer == 7)
            {
                laserParticle.SetActive(true);
                SetNewFollowDestination();
                Debug.Log("Raycast hit position: " + hit.point.x);
                StartCoroutine(DisableLaserCoroutine());
            }
        }
    }

    private IEnumerator DisableLaserCoroutine()
    {
        yield return new WaitForSeconds(.5f);
        laserParticle.SetActive(false);
    }

    private void SetNewFollowDestination()
    {
        if (tvMonsterAiAgent.stateMachine.currentState != AiStateId.Obey)
        {
            tvMonsterAiAgent.stateMachine.ChangeState(AiStateId.Obey);
        }
        tvMonsterAiAgent.tagertPosition = new Vector3(hit.point.x, 0, hit.point.z);
    }
}
