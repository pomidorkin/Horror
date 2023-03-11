using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoomDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] Animator animator;
    [SerializeField] public bool isOpened = false;
    [SerializeField] GameObject subRoomToHide;
    string interactionText = "Open Door";
    string closeInteractionText = "Close Door";

    private void OnEnable()
    {
        playerActions.OnInteractedAction += OpenDoor;
    }

    private void OnDisable()
    {
        playerActions.OnInteractedAction -= OpenDoor;
    }

    private void Start()
    {
        playerActions = FindObjectOfType<PlayerActions>();
    }

    public void OpenDoor(RaycastHit hit, bool isRespawningStage)
    {
        // TODO: Toggle the boolean field (Open/Closed)
        if (hit.transform == this.transform)
        {

            Debug.Log("isOpened " + isOpened);

            if (isOpened == false)
            {
                animator.Play("OpenAnimation");
                this.isOpened = true;
                subRoomToHide.SetActive(false);
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

    public string GetInteractionText()
    {
        // TODO: Return different text depending on the state of the door (Open/Closed)
        if (!isOpened)
        {
            return interactionText;
        }
        else if (isOpened)
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
}
