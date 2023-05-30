using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsSegmentController : MonoBehaviour
{
    [SerializeField] GameObject movableSegment;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] HitEvent hitEvent;
    private Vector3 initialPosition;
    private bool isInRange = false;
    private bool isFallen = false;

    private void OnEnable()
    {
        hitEvent.OnMonsterHitAction += DropMovableSegment;
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += Reset;
    }

    private void OnDisable()
    {
        hitEvent.OnMonsterHitAction -= DropMovableSegment;
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= Reset;
    }

    private void Start()
    {

        initialPosition = movableSegment.transform.position;
    }

    private void Reset()
    {
        movableSegment.transform.position = initialPosition;
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

    private void DropMovableSegment()
    {
        if (isInRange && !isFallen)
        {
            iTween.MoveTo(movableSegment, iTween.Hash("y", 1.5, "time", 2, "islocal", true, "easetype", iTween.EaseType.easeOutBounce));
            isFallen = true;
        }
    }
}
