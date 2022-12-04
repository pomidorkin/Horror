using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraLookController : MonoBehaviour
{
    public class CameraLookControllerEventArgs : EventArgs
    {
        public Transform CameraLookPosition { get; set; }
        public GameObject TriggerEnemy { get; set; }
    }

    public delegate void CameraLookControllerEvent(object source, CameraLookControllerEventArgs args);
    public event CameraLookControllerEvent OnCameraLookControllerEvent;

    public void CameraLookControllerActivated(Transform transform, GameObject enemyTrigger)
    {
        OnCameraLookControllerEvent(this, new CameraLookControllerEventArgs { CameraLookPosition = transform, TriggerEnemy = enemyTrigger });
    }
}
