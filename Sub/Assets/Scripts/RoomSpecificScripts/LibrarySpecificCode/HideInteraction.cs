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
        StartCoroutine(LerpPosition(lookPosition.position, 0.8f));

    }

    public string GetInteractionText()
    {
        return interactionText;
    }

    public void CheckInteracted(RaycastHit hit, bool val)
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

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = /*hidingPosition.position*/playerActions.transform.position;
        while (time < duration)
        {
            playerActions.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        playerActions.transform.position = targetPosition;

        playerActions.transform.position = lookPosition.position;
        playerActions.GetComponent<PlayerMovement>().EnablePlayerMovement();
        mouseLook.EnableCameraMovement();
        virtualCameras[0].LookAt = lookAtSphere.transform;
        foreach (CinemachineVirtualCamera virtualCamera in virtualCameras)
        {
            virtualCamera.gameObject.SetActive(false);
        }



    }
}
