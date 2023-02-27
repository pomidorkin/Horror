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
    [SerializeField] public Transform TargetLookPosition;
    [SerializeField] GameObject[] stoneProps;
    [SerializeField] GameObject[] normalProps;
    [SerializeField] GameObject particleEffect;

    private Vector3 initialPosition;

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
        initialPosition = transform.position;
    }

    public void TurnToStone(bool reset = false)
    {
        if (reset)
        {
            this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.Idle);
            isStone = true;
            morphingTriggered = true;
            aiAgent.noticedPlayer = false;
            aiAgent.navMeshAgent.speed = 0f;
            aiAgent.navMeshAgent.enabled = false;
            animator.SetBool("Follow", false);
            animator.enabled = false;
            foreach (GameObject stoneProp in stoneProps)
            {
                stoneProp.SetActive(true);
            }
            foreach (GameObject normalProp in normalProps)
            {
                normalProp.SetActive(false);
            }
            transform.position = initialPosition;
        }
        else
        {
            this.GetComponent<AiAgent>().stateMachine.ChangeState(AiStateId.Idle);
            isStone = true;
            morphingTriggered = true;
            aiAgent.noticedPlayer = false;
            aiAgent.navMeshAgent.speed = 0f;
            aiAgent.navMeshAgent.enabled = false;
            animator.SetBool("Follow", false);
            animator.enabled = false;
            foreach (GameObject stoneProp in stoneProps)
            {
                stoneProp.SetActive(true);
            }
            foreach (GameObject normalProp in normalProps)
            {
                normalProp.SetActive(false);
            }
            StartCoroutine(ReturnToInitialPosition());
        }
        
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
        if (isStone)
        {
            morphingTriggered = true;
            isStone = false;
            aiAgent.navMeshAgent.enabled = true;
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
                animator.Play("Walk");
                aiAgent.noticedPlayer = true;
            }
        }

        foreach (GameObject stoneProp in stoneProps)
        {
            stoneProp.SetActive(false);
        }
        foreach (GameObject normalProp in normalProps)
        {
            normalProp.SetActive(true);
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

    private IEnumerator ReturnToInitialPosition()
    {
        yield return new WaitForSeconds(3);
        Instantiate(particleEffect, transform.position, Quaternion.identity);
        transform.position = initialPosition;
        //animator.Play("EmptyIdle");
    }
}
