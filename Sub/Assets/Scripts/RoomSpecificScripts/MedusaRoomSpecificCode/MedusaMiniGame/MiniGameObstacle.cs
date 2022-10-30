using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameObstacle : MonoBehaviour
{
    [SerializeField] TestMiniGameController medusaMiniGame;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "2dPlayer")
        {
            medusaMiniGame.MiniGameLose();
        }
    }
}
