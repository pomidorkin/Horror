using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevitatingNPC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //iTween.MoveTo(gameObject, iTween.Hash("x", 5, "time", 1, "islocal", true));
        iTween.MoveTo(gameObject, iTween.Hash("y", .3f, "time", 3f, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
