using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class HideInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayableDirector hidingAnim;
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private bool hideAfterInteraction = false;
    [SerializeField] private Transform hidingPosition;
    [SerializeField] private Transform lookPosition;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject lookAtSphere;
    [SerializeField] private GameObject exitActivateor;

    protected bool interactable = true;
    protected string interactionText = "Hide";

    private void OnEnable()
    {
        playerActions.OnInteractedAction += CheckInteracted;
        hidingAnim.stopped += OnHidingHandler;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= CheckInteracted;
        hidingAnim.stopped -= OnHidingHandler;
    }

    private void OnHidingHandler(PlayableDirector obj)
    {
        exitActivateor.SetActive(true);
        virtualCameras[0].LookAt = null;
        playerActions.GetComponent<PlayerMovement>().DisablePlayerMovement();
        //mouseLook.DisableCameraMovement();
        playerActions.transform.rotation = hidingPosition.rotation;
        playerActions.transform.position = hidingPosition.position;
        animator.Play("ShelfDoorClosingAnimation");
    }

    public void ActivateInteractable()
    {
        // TODO:
        // Hide Character Mesh
        animator.Play("ShelfDoorOpeningAnimation");
        mouseLook.DisableCameraMovement();
    }

    public void OnAnimFinished()
    {
        Debug.Log("HideInteraction");
        foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
        {
            virtualCamera.gameObject.SetActive(true);
        }
        hidingAnim.Play();
    }

    public void PlayExitingAnim()
    {
        animator.Play("ShelfDoorExitAnimation");
    }

    public void ExitHidingPlace()
    {
        exitActivateor.SetActive(false);
        playerActions.transform.position = lookPosition.position;
        virtualCameras[0].LookAt = lookAtSphere.transform;
        mouseLook.EnableCameraMovement();
        //playerActions.GetComponent<PlayerMovement>().EnablePlayerMovement();

    }

    public void EnablePlayerMovement()
    {
        playerActions.GetComponent<PlayerMovement>().EnablePlayerMovement();
    }
    public string GetInteractionText()
    {
        return interactionText;
    }

    public void CheckInteracted(RaycastHit hit)
    {
        if (hit.transform == this.transform && interactable)
        {
            ActivateInteractable();
        }
    }

    public bool GetInteractable()
    {
        return interactable;
    }
}
