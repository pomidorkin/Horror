using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GuardsActivator : MonoBehaviour
{
    public delegate void GuardsActivatedAction();
    public event GuardsActivatedAction OnGuardsActivate;
    [SerializeField] HeadAim headAim;
    [SerializeField] RaycastHead raycastHead;
    [SerializeField] Collider medusaInteractionCollider;
    public bool activated = false;

    public bool trigger = false;
    private void Start()
    {
        //OnGuardsActivate();
    }
    public void GuardsActivated()
    {
        OnGuardsActivate();

        EnableMedusaCollider();
    }

    public void DisableMedusaCollider()
    {
        medusaInteractionCollider.enabled = false;
    }

    public void EnableMedusaCollider()
    {
        medusaInteractionCollider.enabled = true;
    }

    public void ActivateMedusaLaser()
    {
        headAim.headActivated = true;
        headAim.currentTarget = 0;
        activated = true;
        raycastHead.MakeLaserActive(true);
        DisableMedusaCollider();
    }

    public void DeactivateMedusaLaser()
    {
        headAim.headActivated = false;
        headAim.currentTarget = 0;
        activated = false;
        raycastHead.MakeLaserActive(false);
        //EnableMedusaCollider();
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
