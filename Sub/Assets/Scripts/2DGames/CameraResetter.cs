using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetter : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(TimerDisablerCoroutine());
    }

    private IEnumerator TimerDisablerCoroutine()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
