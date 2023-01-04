using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Golem : MonoBehaviour
{
    [SerializeField] private bool noticedPlayer = false;
    [SerializeField] GameObject enemyCopy;
    [SerializeField] public Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MainSceneRespawnManager respawnManager;
    [SerializeField] Transform[] respawnPositions;
    [SerializeField] private RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] private bool isRight = false;
    [SerializeField] GolemSensor golemSensor;
    private bool respawned = true;


    private bool isjumpCounterTextEnabled = false;
    [SerializeField] TMP_Text jumpCounterText;

    // Attack logic
    [SerializeField] AnimationClip attackClip;
    //private float notificationTime = 3.0f;
    //private float timeAndAnimDifference;
    private float attackFrequency = 10.0f;
    private float timer = 0;
    private bool isAttacking = false;

    private void OnEnable()
    {
        //animator.SetTrigger("Reset");
        //timeAndAnimDifference = notificationTime - attackClip.length;
        golemSensor.enabled = true;
        respawnEvenrBroadcaster.OnRespawnTriggeredAction += RespawnEnemy;
        SetGolemsPositionToDefault();
    }

    private void OnDisable()
    {
        respawnEvenrBroadcaster.OnRespawnTriggeredAction -= RespawnEnemy;
    }

    private void Update()
    {
        if (noticedPlayer)
        {
            timer += Time.deltaTime;
            if (timer >= attackFrequency - attackClip.length && !isAttacking)
            {
                isAttacking = true;
                // Play Attack animation
                animator.SetTrigger("Attack");

            }

            if (timer >= attackFrequency)
            {
                //Update Timer From Animation
                //timer = 0.0f;
                // Hide text if not hidden
            }


            if (timer > ((attackFrequency - attackClip.length) - 2f) && timer < ((attackFrequency - attackClip.length) - 1f) && !isjumpCounterTextEnabled)
            {
                jumpCounterText.gameObject.SetActive(true);
                // Set text to 3
                jumpCounterText.text = "3";
                isjumpCounterTextEnabled = true;
            }
            else if (timer > ((attackFrequency - attackClip.length) - 1f) && timer < (attackFrequency - attackClip.length) && isjumpCounterTextEnabled)
            {
                // Set text to 2
                jumpCounterText.text = "2";
            }
            else if (timer > attackFrequency - attackClip.length && isjumpCounterTextEnabled && timer < 9.9f)
            {
                // Set text to 1
                jumpCounterText.text = "Jump!";
                isjumpCounterTextEnabled = false;
                StartCoroutine(HideTextCoroutine());
            }


            if (!respawned)
            {
                respawned = true;
                if (isRight)
                {
                    gameObject.transform.position = respawnPositions[1].position;
                }
                else
                {
                    gameObject.transform.position = respawnPositions[0].position;
                }
            }
        }
        
        

        
    }

    private IEnumerator HideTextCoroutine()
    {
        Debug.Log("Coroutine Started");
        yield return new WaitForSeconds(2f);
        jumpCounterText.gameObject.SetActive(false);
    }

    public void SetNoticedPlayer(bool value)
    {
        noticedPlayer = value;
    }

    public bool GetNoticedPlayer()
    {
        return noticedPlayer;
    }

    /* TODO:
    1. Check is player is grounded when attacked
    2. If player is grounded respawn yourself and the player, using Respawn (without an attribute)
    3. Add different things, such as step noise and camera shake
    4. Add feedback about the upcoming attack
    */

    public void SetEnemyCopyActive(bool value)
    {
        enemyCopy.SetActive(value);
    }

    // Should be called from the animator
    public void CheckIfPlayerIsGrounded()
    {
        timer = 0.0f;
        isAttacking = false;
        // Play Feel & Sound effects
        if (playerMovement.GetIsPlayerGrounded())
        {
            // Kill player & respawn self
            respawned = false;
            animator.SetTrigger("Reset");
            Respawn();
        }
    }

    private void Respawn()
    {
        // It would be good to add a coroutine of some sort and an animation
        
        respawnManager.Respawn();
        SetEnemyCopyActive(true);
        SetNoticedPlayer(false);

        // Set yourself to the enemyRespawn Position
    }

    private void RespawnEnemy()
    {
        //SetEnemyCopyActive(true);
        SetGolemsPositionToDefault();
        //golemSensor.enabled = true;
        //enemyCopy.GetComponent<GolemSensor>().enabled = true;
    }

    private void SetGolemsPositionToDefault()
    {
        if (isRight)
        {
            gameObject.transform.position = respawnPositions[1].position;
            enemyCopy.gameObject.transform.position = respawnPositions[0].position;
        }
        else
        {
            gameObject.transform.position = respawnPositions[0].position;
            enemyCopy.gameObject.transform.position = respawnPositions[1].position;
        }
    }
}