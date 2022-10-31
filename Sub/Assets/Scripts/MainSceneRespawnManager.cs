using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MainSceneRespawnManager : MonoBehaviour, IRespawnManager
{
    //[SerializeField] RoomManager roomManager;
    [SerializeField] RoomParent respawnRoom;
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] ScreamerLookTarget lookTarget;
    public void Respawn(AiScreamerController enemy)
    {
        // TODO: Set respawnRoom position to the middle coridor segment
        // Play dying & waking up animation
        // Собака глючит при повторной встрече
        gameManager.DisablePlayerActions();
        respawnRoom.SpawnRoom(true);
        player.transform.position = respawnRoom.transform.position; // Create a spawning position
        enemy.gameObject.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.Idle);
        enemy.gameObject.GetComponent<AiAgent>().noticedPlayer = false;
        enemy.gameObject.GetComponent<AiSensor>().enabled = true; // Not going to work with the blind enemy and other types of enemies
        enemy.animator.SetBool("Follow", false);
        enemy.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
        StartCoroutine(EnablePlayerActions());
    }

    private IEnumerator EnablePlayerActions()
    {
        yield return new WaitForFixedUpdate();
        gameManager.EnablePlayerActionsAndDisableVirtualCamera();
        lookTarget.Respawn();
    }
}
