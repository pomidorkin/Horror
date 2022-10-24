using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneEnemy : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Material phaseMaterial;
    [SerializeField] private GuardsActivator guardsActivator;
    [SerializeField] private float fadeTime = 5f;
    private bool fadeBackwards = false;
    private float startValue = 1.1f;
    private float destValue = -.1f;
    private bool inProcess = false;
    public bool isStone = true;
    private bool morphingTriggered = true;

    private AiAgent aiAgent;

    private void OnEnable()
    {
        guardsActivator.OnGuardsActivate += OnMorphedToHuman;
    }

    private void OnDisable()
    {
        guardsActivator.OnGuardsActivate -= OnMorphedToHuman;
    }

    // Start is called before the first frame update
    void Start()
    {
        _renderer.material = phaseMaterial;
        aiAgent = this.GetComponent<AiAgent>();
    }

    public void TurnToStone()
    {
        this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.Idle);
        isStone = true;
        morphingTriggered = true;
        aiAgent.noticedPlayer = false;
        aiAgent.navMeshAgent.speed = 0f;
        animator.SetBool("Follow", false);
        animator.enabled = false;
    }

    public void DoFade(float start, float dest, float time)
    {
        iTween.ValueTo(gameObject, iTween.Hash(
            "from", start, "to", dest, "time", time, "onupdatetarget", gameObject,
            "onupdate", "TweenOnUpdate", "oncomplete", "TweenOnComplete", "easetype", iTween.EaseType.easeInOutCubic
            ));
    }

    void TweenOnUpdate(float value)
    {
        _renderer.material.SetFloat("_ChangeValue", value);
    }

    void TweenOnComplete()
    {
        //fadeBackwards = !fadeBackwards;
        inProcess = false;
    }

    private void OnMorphedToHuman()
    {
        morphingTriggered = true;
        isStone = false;
        aiAgent.navMeshAgent.speed = aiAgent.defaultSpeed;
        animator.enabled = true;
        Debug.Log("I noticed the player");
        if (!aiAgent.noticedPlayer)
        {
            if (aiAgent.enemyType == AiAgent.EnemyType.Crabwalk)
            {
                aiAgent.stateMachine.ChangeState(AiStateId.Transition);
            }
            else if (aiAgent.enemyType == AiAgent.EnemyType.EvilGirl)
            {
                GetComponent<SpawnEffect>().DoFade(0f, 2f, 2f);
            }
            else
            {
                aiAgent.stateMachine.ChangeState(AiStateId.ChasePlayer);
            }
            animator.SetBool("Follow", true);
            aiAgent.noticedPlayer = true;
        }
    }

    private void Update()
    {
        if (morphingTriggered && !inProcess && isStone)
        {
            inProcess = true;
            if (fadeBackwards)
            {
                DoFade(destValue, startValue, fadeTime);
            }
            else
            {
                DoFade(startValue, destValue, fadeTime);
            }
            fadeBackwards = !fadeBackwards;
            morphingTriggered = false;
        }
        else if (morphingTriggered && !inProcess && !isStone)
        {
            inProcess = true;
            if (fadeBackwards)
            {
                DoFade(destValue, startValue, fadeTime);
            }
            else
            {
                DoFade(startValue, destValue, fadeTime);
            }
            fadeBackwards = !fadeBackwards;
            morphingTriggered = false;
        }
    }
}
