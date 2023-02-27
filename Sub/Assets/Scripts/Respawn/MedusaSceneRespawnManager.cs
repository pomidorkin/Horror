using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaSceneRespawnManager : MonoBehaviour, IRespawnManager
{
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform respawnPosition;
    [SerializeField] ScreamerLookTarget lookTarget;
    [SerializeField] PlayerManager playerManager;

    // Medusa Scene Logic
    [SerializeField] RaycastHead raycastHead;
    [SerializeField] GuardsActivator guardsActivator;
    [SerializeField] HeadAim headAim;
    //[SerializeField] MedusaInteractable medusaInteractable;

    // UI
    [SerializeField] GameObject respawnUI;
    [SerializeField] GameObject WakeUPUI;

    public void Respawn(AiScreamerController enemy)
    {
        Debug.Log("Respawn Triggered");
        Respawn();

        // Enemies
        AiAgent agent = enemy.gameObject.GetComponent<AiAgent>();
        //agent.stateMachine.ChangeState(AiStateId.Wander);
        //agent.noticedPlayer = false;
        //enemy.gameObject.GetComponent<AiSensor>().enabled = true; // Not going to work with the blind enemy and other types of enemies
        //enemy.animator.SetBool("Follow", false);
        //enemy.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
        //respawnEvenrBroadcaster.InvokeRespawnAction();

        // Medusa Scene Respawn Logic
        headAim.ResetHeadAim();
        headAim.ResetEnemies();
        raycastHead.MakeLaserActive(false);
        guardsActivator.DeactivateMedusaLaser();
        guardsActivator.DisableMedusaCollider();
        

        lookTarget.Respawn();
    }

    public void Respawn()
    {
        gameManager.DisablePlayerActions();
        playerManager.SetPlayerScared(false);
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
