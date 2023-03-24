using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class RotationLever : MonoBehaviour, IInteractable
{
    [SerializeField] RotateRoomSegment rotateRoomSegment;
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] RotatingRoomLever rotatingRoomLever;
    public LocalizedString localizedInteractionText;
    private bool interactable = true;

    private void OnEnable()
    {
        playerActions.OnInteractedAction += RotateRoom;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= RotateRoom;
    }

    private void RotateRoom(RaycastHit hit, bool isRespawnStage)
    {
        if (hit.transform == this.transform && interactable)
        {
            rotateRoomSegment.RotateSegment();
            rotatingRoomLever.PlayLeverAnimation();
            interactable = false;
            StartCoroutine(ResetInteractable());
        }
        
    }
    public string GetInteractionText()
    {
        return localizedInteractionText.GetLocalizedString();
    }

    public bool GetInteractable()
    {
        return interactable;
    }

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }

    private IEnumerator ResetInteractable()
    {
        yield return new WaitForSeconds(3f);
        interactable = true;
    }
}
