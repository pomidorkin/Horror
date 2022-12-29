using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsBroadcaster : MonoBehaviour
{
    public delegate void HidePerformedAction();
    public event HidePerformedAction OnHidePerformedAction;

    // TEST DELETE
    public bool test = false;

    public void HidePerformed()
    {
        OnHidePerformedAction();
    }

    // TEST
    private void Update()
    {
        if (test)
        {
            test = false;
            HidePerformed();
        }
    }
}
