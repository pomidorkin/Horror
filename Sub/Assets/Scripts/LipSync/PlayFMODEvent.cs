using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class PlayFMODEvent : MonoBehaviour
{
    [SerializeField] private EventReference AudioEventPath;
    private void OnEnable()
    {
        EventInstance Audio = FMODUnity.RuntimeManager.CreateInstance(AudioEventPath);        // If they are, we create an FMOD event instance. We use the event path inside the 'FootstepsEventPath' variable to find the event we want to play.
        RuntimeManager.AttachInstanceToGameObject(Audio, transform, GetComponent<Rigidbody>());     // Next that event instance is told to play at the location that our player is currently at.
        Audio.start();                                                                                        // We then play a footstep!.
        Audio.release();
    }
}
