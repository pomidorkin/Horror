using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuardsActivator : MonoBehaviour
{
    public delegate void GuardsActivatedAction();
    public event GuardsActivatedAction OnGuardsActivate;
    [SerializeField] HeadAim headAim;
    public bool activated = false;

    public bool trigger = false;
    private void Start()
    {
        //OnGuardsActivate();
    }
    public void GuardsActivated()
    {
        OnGuardsActivate();
        headAim.headActivated = true;
        headAim.currentTarget = 0;
        activated = true;
    }

    

    private void Update()
    {
        // TEST
        if (trigger == true)
        {
            trigger = false;
            GuardsActivated();
        }
        //
    }
}
