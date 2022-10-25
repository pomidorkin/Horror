using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHead : MonoBehaviour
{
    [SerializeField] Transform laserOrigin;
    [SerializeField] Transform aim;
    [SerializeField] GuardsActivator guardsActivator;
    [SerializeField] GameObject particle;
    private float laserRange = 50f;
    private bool laserActivated = false;

    LineRenderer laserLine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (guardsActivator.activated && !laserActivated)
        {
            laserActivated = true;
            laserLine.enabled = true;
            particle.SetActive(true);
        }
        if (laserActivated)
        {
            laserLine.SetPosition(0, laserOrigin.position);
            Vector3 rayOrigin = laserOrigin.forward;
            RaycastHit hit;
            laserLine.SetPosition(1, aim.position);
        }
        
    }
}
