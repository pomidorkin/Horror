using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private bool noticedPlayer = false;
    [SerializeField] GameObject enemyCopy;
    [SerializeField] public Animator animator;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] MainSceneRespawnManager respawnManager;
    [SerializeField] Transform[] respawnPositions;
    [SerializeField] private RespawnEvenrBroadcaster respawnEvenrBroadcaster;
    [SerializeField] private bool isRight = false;
    [SerializeField] GolemSensor golemSensor;

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
        timer += Time.deltaTime;
        if (timer >= attackFrequency - attackClip.length && !isAttacking)
        {
            isAttacking = true;
            // Play Attack animation
            animator.SetTrigger("Attack");
            if (timer >= attackFrequency)
            {
                //Update Timer From Animation
                //timer = 0.0f;
                // Hide text if not hidden
            }

            if (timer < 3.0f && timer > 2.0f)
            {
                // Set text to 3
            }
            else if (timer < 2.0f && timer > 1.0f)
            {
                // Set text to 2
            }
            else if (timer < 1.0f && timer > 0.0f)
            {
                // Set text to 1
            }
        }

        
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
            animator.SetTrigger("Reset");
            Respawn();
        }
    }

    private void Respawn()
    {
        // It would be good to add a coroutine of some sort and an animation
        
        respawnManager.Respawn();
        SetEnemyCopyActive(true);
        // Set yourself to the enemyRespawn Position
    }

    private void RespawnEnemy()
    {
        //SetEnemyCopyActive(true);
        SetGolemsPositionToDefault();
    }

    private void SetGolemsPositionToDefault()
    {
        if (isRight)
        {
            this.gameObject.transform.position = respawnPositions[1].position;
            //enemyCopy.gameObject.transform.position = respawnPositions[0].position;
        }
        else
        {
            this.gameObject.transform.position = respawnPositions[0].position;
            //enemyCopy.gameObject.transform.position = respawnPositions[1].position;
        }
        
    }
}
