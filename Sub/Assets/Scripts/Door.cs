using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] bool isRightDoor = false;
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] Transform roomPosition;
    [SerializeField] DoorManager doorManager;
    [SerializeField] Animator animator;
    string interactionText = "Open Door";
    string closeInteractionText = "Close Door";

    private AllDoorController allDoorController;

    [SerializeField] public bool isOpened = false;
    [SerializeField] public bool canBeOpened = false;
    [SerializeField] public bool isInteractable = true;

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
        allDoorController = FindObjectOfType<AllDoorController>();
    }

    public void OpenDoor(RaycastHit hit)
    {
        // TODO: Toggle the boolean field (Open/Closed)
        if (hit.transform == this.transform)
        {
            
            Debug.Log("isOpened " + isOpened);

            if (isOpened == false && canBeOpened == true)
            {
                allDoorController.CloseAllDoors();
                animator.Play("OpenAnimation");
                this.isOpened = true;
                Debug.Log("I am the door and I am being opened..." + " isOpened " + isOpened);
                doorManager.DoorOpened(roomPosition, isRightDoor);
            }
            else if (!isOpened && !canBeOpened)
            {
                animator.Play("DoorLockedAnimation");
            }
            else
            {
                CloseDoor();
            }
            
        }
    }

    public void CloseDoor()
    {
        if (isOpened)
        {
            isOpened = false;
            animator.Play("CloseAnimation");
            Debug.Log("CloseAnimation");
        }
        
    }

    private void OnEnable()
    {
        playerActions.OnInteractedAction += OpenDoor;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= OpenDoor;
    }

    public string GetInteractionText()
    {
        // TODO: Return different text depending on the state of the door (Open/Closed)
        if (!isOpened && isInteractable)
        {
            return interactionText;
        }
        else if(isOpened && isInteractable)
        {
            return closeInteractionText;
        }
        else
        {
            return "";
        }
    }
}
