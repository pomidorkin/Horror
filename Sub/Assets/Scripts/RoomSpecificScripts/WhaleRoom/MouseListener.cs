using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseListener : MouseInterface
{
    [SerializeField] private Animator animator;
    [SerializeField] PlayerThimblesController playerThimblesController;
    [SerializeField] GameObject fanObject;
    [SerializeField] GameObject fanCollider;
    /*public void LeftButtonPressed()
    {
        Debug.Log("Lefm Mouse Button was Pressed");
        ActivateFan();
    }*/

    public override void LeftButtonPressed()
    {
        Debug.Log("Lefm Mouse Button was Pressed");
        ActivateFan();
    }

    private void ActivateFan()
    {
        if (playerThimblesController.GetFanPicked())
        {
            playerThimblesController.FanPicked(false);
            fanObject.SetActive(true);
            fanCollider.SetActive(true);
            animator.Play("Blow");
            StartCoroutine(DisableFanObject());
            playerThimblesController.MakeSenseiInteractable();
        }
    }

    private IEnumerator DisableFanObject()
    {
        yield return new WaitForSeconds(3f);
        fanObject.SetActive(false);
        fanCollider.SetActive(false);
    }
}
