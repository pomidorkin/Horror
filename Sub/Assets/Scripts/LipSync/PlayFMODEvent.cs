using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System;

public class PlayFMODEvent : MonoBehaviour
{
    [SerializeField] private EventReference AudioEventPath;
    [SerializeField] private PauseMenu pauseMenu;
    EventInstance Audio;
    private void OnEnable()
    {
        pauseMenu.OnGamePausedAction += GamePausedHandler;
        Audio = FMODUnity.RuntimeManager.CreateInstance(AudioEventPath);        // If they are, we create an FMOD event instance. We use the event path inside the 'FootstepsEventPath' variable to find the event we want to play.
        RuntimeManager.AttachInstanceToGameObject(Audio, transform, GetComponent<Rigidbody>());     // Next that event instance is told to play at the location that our player is currently at.
        Audio.start();                                                                                        // We then play a footstep!.
        Audio.release();
    }

    private void OnDisable()
    {
        pauseMenu.OnGamePausedAction -= GamePausedHandler;
    }

    private void GamePausedHandler(object source, PauseMenu.GamePausedEventArgs args)
    {
        PauseSound(!args.IsPaused);
    }

    private void PauseSound(bool value)
    {
        Audio.setPaused(value);
    }
}
