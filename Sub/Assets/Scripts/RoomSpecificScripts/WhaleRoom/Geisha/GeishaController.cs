using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeishaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash("y", .3f, "islocal", true, "time", 3f, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 25 * Time.deltaTime, 0);
    }
}
