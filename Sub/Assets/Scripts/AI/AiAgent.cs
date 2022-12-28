using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateMachine stateMachine;
    public AiStateId initialState;
    public NavMeshAgent navMeshAgent;
    [SerializeField] public Transform followObject;
    [SerializeField] public Transform targetLookPosition;
    [SerializeField] public Transform eyesForNpc;
    [SerializeField] public CameraLookController jumpScare;
    [SerializeField] public bool hasTransitionState;
    [SerializeField] public EnemyType enemyType;
    [SerializeField] public WanderType wanderType;
    [SerializeField] public GameObject modelRotator;
    [SerializeField] public GameObject characterModel;
    public AiAgentConfig config;
    public bool transitionAnimationCompleted = false; // Crabwalk enemy
    //public Ragdoll ragdoll;
    public AiSensor sensor;
    public bool noticedPlayer = false;
    public float defaultSpeed;

    public Transform[] followPositions;


    public enum EnemyType { Crabwalk, EvilGirl, Wanderer, Other};
    public enum WanderType { Random, Predetermined};

    public void Init(Transform followObject, CameraLookController jumpScare)
    {
        this.followObject = followObject;
        eyesForNpc = followObject;
        this.jumpScare = jumpScare;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ragdoll = GetComponent<Ragdoll>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        sensor = GetComponent<AiSensor>();

        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerScript());
        stateMachine.RegisterState(new AiTransitionState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiJumpscareState());
        stateMachine.RegisterState(new AiWanderState());
        stateMachine.RegisterState(new AiFollowTargetState());
        stateMachine.RegisterState(new AiAttackState());
        stateMachine.ChangeState(initialState);

        defaultSpeed = navMeshAgent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void SetTransitionAnimationCompleted(int value)
    {
        transitionAnimationCompleted = value == 1 ? true : false;
        Debug.Log("SetTransitionAnimationCompleted");
    }

    public void SetSpeedToDefault()
    {
        navMeshAgent.speed = defaultSpeed;
    }
}