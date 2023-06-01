using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    [SerializeField] GameObject appleObject;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] HitEvent hitEvent;
    [SerializeField] AppleController appleController;
    private Vector3 initialPosition;
    private bool isInRange = false;
    private bool isFallen = false;
    private bool crossDoorOpened = false;
    private void OnEnable()
    {
        hitEvent.OnMonsterHitAction += DropApple;
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += Reset;
    }

    private void OnDisable()
    {
        hitEvent.OnMonsterHitAction -= DropApple;
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= Reset;
    }

    private void Start()
    {
        initialPosition = appleObject.transform.position;
    }

    private void Reset()
    {
        appleObject.transform.position = initialPosition;
        isInRange = false;
        isFallen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "TVMonster")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TVMonster")
        {
            isInRange = false;
        }
    }

    public void DropApple()
    {
        Debug.Log("DropApple called. Is In range = " + isInRange);
        if (isInRange && !isFallen && !crossDoorOpened)
        {
            iTween.MoveTo(appleObject, iTween.Hash("y", 0, "time", 2, "oncomplete", "ActionAfterTweenComplete", "islocal", true, "easetype", iTween.EaseType.easeOutBounce));
            isFallen = true;
        }
    }

    public void ResetApplePosition()
    {
        appleObject.transform.position = initialPosition;
        isFallen = false;
    }
}
