using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorController : InteractionParent
{
    [SerializeField] Animator animator;

    public override void ActivateInteractable()
    {
        animator.Play("ElevatorDoorsOpenAnim");
    }

    public void CloseElevatorDoors()
    {
        animator.Play("ElevatorDoorsCloseAnim");
    }

    public void MakeUninteractable()
    {
        this.interactable = false;
    }

    public void LoandScene()
    {
        SceneManager.LoadScene(1);
    }
}
