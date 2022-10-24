using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuardsActivator : MonoBehaviour
{
    public delegate void GuardsActivatedAction();
    public event GuardsActivatedAction OnGuardsActivate;

    public bool trigger = false;

    public void GuardsActivated()
    {
        //OnGuardsActivate();
    }

    private void Start()
    {
        OnGuardsActivate();
    }

    private void Update()
    {
        // TEST
        if (trigger == true)
        {
            trigger = false;
            OnGuardsActivate();
        }
        //
    }
}
