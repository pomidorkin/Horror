using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamerLookTarget : MonoBehaviour
{
    private Transform activeLookPos;
    private Vector3 initialPosition;
    [SerializeField] float posLerpTime = 1f;
    private float startTime;
    private float journeyLength;
    Vector3 posBeggin;
    [SerializeField] CameraLookController cameraLookController;
    bool jumpScareActivated = false;

    private void OnEnable()
    {
        cameraLookController.OnCameraLookControllerEvent += ActivateCamLookPosition;
    }

    private void OnDisable()
    {
        cameraLookController.OnCameraLookControllerEvent -= ActivateCamLookPosition;
    }

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void ActivateCamLookPosition(object source, CameraLookController.CameraLookControllerEventArgs args)
    {
        jumpScareActivated = true;
        posBeggin = transform.position;
        activeLookPos = args.CameraLookPosition;
        //activeScreamerPos.position = activeScreamerPos.position + new Vector3(0, 0.75f, 0);
        startTime = Time.time;
        journeyLength = Vector3.Distance(posBeggin, activeLookPos.position);
    }

    private void Update()
    {
        if (jumpScareActivated && transform.position != activeLookPos.position)
        {
            LookAtTarget();
        }
    }

    public void LookAtTarget()
    {
        float distCovered = (Time.time - startTime) * posLerpTime;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(posBeggin, activeLookPos.position, fractionOfJourney);
    }
}
