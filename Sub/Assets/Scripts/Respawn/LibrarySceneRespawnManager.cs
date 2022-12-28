using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibrarySceneRespawnManager : MonoBehaviour, IRespawnManager
{
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform respawnPosition;
    [SerializeField] ScreamerLookTarget lookTarget;

    // UI
    [SerializeField] GameObject respawnUI;
    [SerializeField] GameObject WakeUPUI;

    public void Respawn(AiScreamerController enemy)
    {
        Respawn();

        // Enemies
        AiAgent agent = enemy.gameObject.GetComponent<AiAgent>();
        agent.stateMachine.ChangeState(AiStateId.Wander);
        agent.noticedPlayer = false;
        enemy.gameObject.GetComponent<AiSensor>().enabled = true; // Not going to work with the blind enemy and other types of enemies
        enemy.animator.SetBool("Follow", false);
        enemy.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
        respawnEvenrBroadcaster.InvokeRespawnAction();

        lookTarget.Respawn();
    }

    public void Respawn()
    {
        gameManager.DisablePlayerActions();
        gameManager.SetRespawningStage(true);

        player.transform.position = respawnPosition.position;
        player.transform.rotation = respawnPosition.rotation;

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

    public void RespawnRoom()
    {
    }
}
