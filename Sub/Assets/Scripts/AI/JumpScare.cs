using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JumpScare : MonoBehaviour
{
    public class JumpScareEventArgs : EventArgs
    {
        public Transform JumpScarePosition { get; set; }
    }

    public delegate void JumpScareEvent(object source, JumpScareEventArgs args);
    public event JumpScareEvent OnJumpScareEvent;

    public void JumpScareActivated(Transform transform)
    {
        OnJumpScareEvent(this, new JumpScareEventArgs { JumpScarePosition = transform });
    }
}
