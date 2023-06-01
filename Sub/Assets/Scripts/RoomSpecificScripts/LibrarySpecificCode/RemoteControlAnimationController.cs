using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControlAnimationController : MonoBehaviour
{
    public void PlayITweenAnim()
    {
        iTween.RotateBy(gameObject, iTween.Hash("y", 1, "time", 2, "islocal", true, "easetype", iTween.EaseType.easeInBack));
    }
}
