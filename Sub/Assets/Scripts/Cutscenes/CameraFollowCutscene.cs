using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCutscene : MonoBehaviour
{
    [SerializeField] Transform target;

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition = new Vector3(target.localPosition.x, 0 , target.localPosition.z);
        //this.transform.rotation = Quaternion.identity;
    }
}
