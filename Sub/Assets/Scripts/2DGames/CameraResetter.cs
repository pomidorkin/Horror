using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResetter : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManager;
    private void OnEnable()
    {
        gameManager.DisablePlayerActions();
        StartCoroutine(TimerDisablerCoroutine());
    }

    private IEnumerator TimerDisablerCoroutine()
    {
        yield return new WaitForSeconds(2);
        gameManager.EnablePlayerActions();
        gameObject.SetActive(false);
    }
}
