using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadObject : MonoBehaviour
{
    [SerializeField] Transform aim;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.LookAt(aim.transform);
    }
}
