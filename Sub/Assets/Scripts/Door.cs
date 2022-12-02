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

    public void OpenDoor(RaycastHit hit, bool isRespawningStage)
    {
        // TODO: Toggle the boolean field (Open/Closed)
        if (hit.transform == this.transform)
        {
            
            Debug.Log("isOpened " + isOpened);

            if (isOpened == false && canBeOpened == true && !isRespawningStage)
            {
                allDoorController.CloseAllDoors();
                animator.Play("OpenAnimation");
                this.isOpened = true;
                Debug.Log("I am the door and I am being opened..." + " isOpened " + isOpened);
                doorManager.DoorOpened(roomPosition, isRightDoor);
            }
            else if (!isOpened && !canBeOpened && !isRespawningStage)
            {
                // The Code below runs when we try to oped a locked door and
                // the corridor stage goal is set to Stage.GoalType.doorsAndAmount
                if (allDoorController.stageManager.currentStage.goalType == Stage.GoalType.doorsAndAmount && !allDoorController.WasLastUsedDoor(this))
                {
                    allDoorController.SetLastUsedDoor(this);
                    allDoorController.stageManager.currentStage.stageGoal.AddDoorsInteractionNumber();
                }
                animator.Play("DoorLockedAnimation");
            }
            else if (!isOpened && isRespawningStage)
            {
                allDoorController.CloseAllDoors();
                animator.Play("OpenAnimation");
                this.isOpened = true;
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
            doorManager.stageManager.currentStage.stageGoal.CheckIfGoalIsReached(); // DECORATION STAGE
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

    public bool GetInteractable()
    {
        return true;
    }

    public Transform GetRoomPosition()
    {
        return roomPosition;
    }

    public bool IsRightDoor()
    {
        return isRightDoor;
    }
}
