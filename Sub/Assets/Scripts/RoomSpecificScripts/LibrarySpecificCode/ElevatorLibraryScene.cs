using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLibraryScene : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LibraryIntro libraryIntro;

    private void Start()
    {
        animator.Play("ElevatorDoorsOpenAnimSecondScene");
    }

    public void ActivateCutscene()
    {
        libraryIntro.MovePlayerIntro();
    }
}
