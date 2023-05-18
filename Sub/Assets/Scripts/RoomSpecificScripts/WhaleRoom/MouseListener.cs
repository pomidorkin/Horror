using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseListener : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void LeftButtonPressed()
    {
        Debug.Log("Lefm Mouse Button was Pressed");
        ActivateFan();
    }

    private void ActivateFan()
    {
        animator.Play("Blow");
    }
}
