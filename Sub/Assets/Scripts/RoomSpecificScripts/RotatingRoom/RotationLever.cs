using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLever : MonoBehaviour, IInteractable
{
    [SerializeField] RotateRoomSegment rotateRoomSegment;
    [SerializeField] private PlayerActions playerActions;
    string interactionText = "Rotate";

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
        if (hit.transform == this.transform)
        {
            rotateRoomSegment.RotateSegment();
        }
        
    }
    public string GetInteractionText()
    {
        return interactionText;
    }

    public bool GetInteractable()
    {
        return true;
    }

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }
}
