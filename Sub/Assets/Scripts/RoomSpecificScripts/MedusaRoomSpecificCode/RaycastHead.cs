using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHead : MonoBehaviour
{
    [SerializeField] Transform laserOrigin;
    [SerializeField] Transform aim;
    private float laserRange = 50f;

    LineRenderer laserLine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = laserOrigin.forward;
        RaycastHit hit;
        /*if (Physics.Raycast(rayOrigin, laserOrigin.forward, out hit, laserRange))
        {
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (laserOrigin.forward * laserRange));
        }*/
        laserLine.SetPosition(1, aim.position);
    }
}
