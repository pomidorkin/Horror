using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRoomLever : MonoBehaviour
{

    public void PlayLeverAnimation()
    {
        iTween.RotateBy(this.gameObject, iTween.Hash("x", .13, "easeType", "easeInOutBack", "time", 1.5f, "delay", .4));
        StartCoroutine(PlayBackAnimation());
    }

    private IEnumerator PlayBackAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        iTween.RotateBy(this.gameObject, iTween.Hash("x", -.13, "easeType", "easeInOutBack", "time", 1.5f, "delay", .4));
    }
}
