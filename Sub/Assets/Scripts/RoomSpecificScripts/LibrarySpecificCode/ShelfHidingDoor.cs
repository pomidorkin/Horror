using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfHidingDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationCompleted()
    {
        GetComponentInParent<HideInteraction>().OnAnimFinished();
    }

    public void ExitShelf()
    {
        GetComponentInParent<HideInteraction>().ExitHidingPlace();
    }

    public void EnableWalking()
    {
        GetComponentInParent<HideInteraction>().EnablePlayerMovement();
    }
}
