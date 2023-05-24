using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestReurtnScene : InteractionParent
{
    public override void ActivateInteractable()
    {
        SceneManager.LoadScene(0);
    }
}
