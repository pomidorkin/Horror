using System.Collections;
using UnityEngine;

public class MainSceneRespawnManager : MonoBehaviour, IRespawnManager
{
    //[SerializeField] RoomManager roomManager;
    [SerializeField] RoomParent respawnRoom;
    [SerializeField] GameObject player;
    [SerializeField] GameManagerScript gameManager;
    [SerializeField] ScreamerLookTarget lookTarget;
    [SerializeField] SegmentsParent segmentsParent;
    [SerializeField] RoomManager roomManager;
    [SerializeField] RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] Transform respawnPosition;
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
        // Rooms
        centerSegment = segmentsParent.FindMiddleSegment();
        roomManager.DespawnAllRooms();
        gameManager.SetRespawningStage(true);

        
        // Play dying & waking up animation
        // Собака глючит при повторной встрече
        gameManager.DisablePlayerActions();
        respawnRoom.SpawnRoom(true);

        //Player
        if (centerSegment.GetComponentInChildren<Door>().IsRightDoor())
        {
            respawnRoom.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        respawnRoom.transform.position = centerSegment.GetComponentInChildren<Door>().GetRoomPosition().position;
        //player.transform.position = new Vector3(respawnRoom.transform.position.x, respawnRoom.transform.position.y, respawnRoom.transform.position.z -2f); // Create a spawning position
        player.transform.position = respawnPosition.position;

        // Enemies
        AiAgent agent = enemy.gameObject.GetComponent<AiAgent>();
        agent.stateMachine.ChangeState(AiStateId.Idle);
        agent.noticedPlayer = false;
        //enemy.gameObject.GetComponent<NavMeshAgent>().speed = agent.defaultSpeed;
        enemy.gameObject.GetComponent<AiSensor>().enabled = true; // Not going to work with the blind enemy and other types of enemies
        enemy.animator.SetBool("Follow", false);
        enemy.animator.SetBool("Reset", true); // Тут тоже какая-то хуета
        respawnEvenrBroadcaster.InvokeRespawnAction();

        //StartCoroutine(EnablePlayerActions());
        lookTarget.Respawn();
        player.transform.rotation = respawnPosition.rotation;
        PlayWakeUPAnim();

        respawnUI.SetActive(false);
    }

    public void Respawn()
    {
        // Rooms
        centerSegment = segmentsParent.FindMiddleSegment();
        roomManager.DespawnAllRooms();
        gameManager.SetRespawningStage(true);


        // Play dying & waking up animation
        // Собака глючит при повторной встрече
        gameManager.DisablePlayerActions();
        respawnRoom.SpawnRoom(true);

        //Player
        if (centerSegment.GetComponentInChildren<Door>().IsRightDoor())
        {
            respawnRoom.transform.eulerAngles = new Vector3(0, -180, 0);
        }
        respawnRoom.transform.position = centerSegment.GetComponentInChildren<Door>().GetRoomPosition().position;
        player.transform.position = respawnPosition.position;
        respawnEvenrBroadcaster.InvokeRespawnAction();

        //StartCoroutine(EnablePlayerActions());
        //lookTarget.Respawn();
        player.transform.rotation = respawnPosition.rotation;
        PlayWakeUPAnim();

        respawnUI.SetActive(false);
    }

    public void PlayRespawnUIAnim()
    {
        // UI TEST
        respawnUI.SetActive(true);
        // END UI TEST
    }

    private void PlayWakeUPAnim()
    {
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
        //lookTarget.Respawn();
    }
}
