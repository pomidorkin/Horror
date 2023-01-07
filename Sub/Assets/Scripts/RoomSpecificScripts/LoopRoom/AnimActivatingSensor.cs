using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimActivatingSensor : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playableDirector.Play();
        }
    }
}
