using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerLookTarget : MonoBehaviour
{
    private Transform activeScreamerPos;
    [SerializeField] float posLerpTime = 1f;
    private float startTime;
    private float journeyLength;
    Vector3 posBeggin;
    [SerializeField] JumpScare jumpScare;
    bool jumpScareActivated = false;

    private void OnEnable()
    {
        jumpScare.OnJumpScareEvent += ActivateCamLookPosition;
    }

    private void OnDisable()
    {
        jumpScare.OnJumpScareEvent -= ActivateCamLookPosition;
    }

    private void ActivateCamLookPosition(object source, JumpScare.JumpScareEventArgs args)
    {
        jumpScareActivated = true;
        posBeggin = transform.position;
        activeScreamerPos = args.JumpScarePosition;
        //activeScreamerPos.position = activeScreamerPos.position + new Vector3(0, 0.75f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(posBeggin, activeScreamerPos.position);
    }

    private void Update()
    {
        if (jumpScareActivated && transform.position != activeScreamerPos.position)
        {
            LookAtScreamer();
        }
    }

    public void LookAtScreamer()
    {
        float distCovered = (Time.time - startTime) * posLerpTime;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(posBeggin, activeScreamerPos.position, fractionOfJourney);
    }
}
