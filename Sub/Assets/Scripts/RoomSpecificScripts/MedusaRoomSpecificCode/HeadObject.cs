using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadObject : MonoBehaviour
{
    [SerializeField] Transform aim;
    [SerializeField] GuardsActivator guardsActivator;

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.LookAt(aim.transform);
        if (guardsActivator.activated)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(aim.transform.position.x, 0, aim.transform.position.z));
        }
        //transform.rotation = Quaternion.LookRotation(aim.transform.position);
    }
}
