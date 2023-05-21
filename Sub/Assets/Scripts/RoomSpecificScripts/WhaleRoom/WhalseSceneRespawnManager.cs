using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhalseSceneRespawnManager : MonoBehaviour
{
    public delegate void RespawnEventAction();
    public event RespawnEventAction OnRespawnAction;
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] Transform respawnPosition;
    [SerializeField] ScreamerLookTarget lookTarget;
    [SerializeField] GameObject respawnUI;
    [SerializeField] GameObject WakeUPUI;
    //[SerializeField] GameObject geishaCutscene;
    //[SerializeField] GameObject geishaObject;
    public void TriggerRespawnEvent()
    {
        OnRespawnAction();
        Respawn();
    }

    private void Respawn()
    {
        gameManager.DisablePlayerActions();
        player.transform.position = respawnPosition.position;
        player.transform.rotation = respawnPosition.rotation;
        //geishaCutscene.SetActive(false);
        //geishaObject.SetActive(true);
        PlayWakeUPAnim();
    }

    public void PlayRespawnUIAnim()
    {
        respawnUI.SetActive(true);
    }

    private void PlayWakeUPAnim()
    {
        respawnUI.SetActive(false);
        WakeUPUI.SetActive(true);
        StartCoroutine(WakeUpCoroutine());

    }

    private IEnumerator WakeUpCoroutine()
    {
        // По хорошему не корутиной делать, а ивентом из анимации
        yield return new WaitForSeconds(1);
        StartCoroutine(EnablePlayerActions());
        WakeUPUI.SetActive(false);
    }

    private IEnumerator EnablePlayerActions()
    {
        yield return new WaitForFixedUpdate();
        gameManager.EnablePlayerActionsAndDisableVirtualCamera();
    }
}
