using System.Collections;
using UnityEngine;

public class MainSceneRespawnManager : MonoBehaviour, IRespawnManager
{
    //[SerializeField] RoomManager roomManager;
    [SerializeField] RoomParent respawnRoom;
    [SerializeField] GameObject respawnRoomLeavingSensor;
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] ScreamerLookTarget lookTarget;
    [SerializeField] SegmentsParent segmentsParent;
    [SerializeField] RoomManager roomManager;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform respawnPosition;
    [SerializeField] AllDoorController allDoorController;
    private Segment centerSegment;

    [SerializeField] GameObject respawnUI;
    [SerializeField] GameObject WakeUPUI;
    //[SerializeField] Animator WakeUpUIAnimator;

    private void Start()
    {
        Respawn();
    }

    public void Respawn(AiScreamerController enemy)
    {
        // Respawn when the player dies
        Respawn();

        // Enemies
        AiAgent agent = enemy.gameObject.GetComponent<AiAgent>();
        agent.stateMachine.ChangeState(AiStateId.Idle);
        agent.noticedPlayer = false;
        enemy.gameObject.GetComponent<AiSensor>().enabled = true; // Not going to work with the blind enemy and other types of enemies
        enemy.animator.SetBool("Follow", false);
        enemy.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
        respawnEvenrBroadcaster.InvokeRespawnAction();

        lookTarget.Respawn();
    }

    public void Respawn()
    {
        // Respawn when the stage is started

        centerSegment = segmentsParent.FindMiddleSegment();
        gameManager.DisablePlayerActions();
        gameManager.SetRespawningStage(true);
        allDoorController.CloseAllDoors();
        roomManager.DespawnAllRooms();
        respawnRoom.SpawnRespawnRoom();

        respawnRoom.transform.position = centerSegment.GetComponentInChildren<Door>().GetRoomPosition().position;
        respawnRoom.transform.eulerAngles = new Vector3(0, -180, 0);

        player.transform.position = respawnPosition.position;
        player.transform.rotation = respawnPosition.rotation;

        StartCoroutine(RespawnRoomCoroutine());
        
        PlayWakeUPAnim();
    }

    public void PlayRespawnUIAnim()
    {
        // UI TEST
        respawnUI.SetActive(true);
        // END UI TEST
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



    private IEnumerator RespawnRoomCoroutine()
    {
        yield return new WaitForFixedUpdate();
        respawnRoomLeavingSensor.SetActive(true);
    }

    public void RespawnRoom()
    {
        respawnRoom.SpawnRespawnRoom();
    }
}
