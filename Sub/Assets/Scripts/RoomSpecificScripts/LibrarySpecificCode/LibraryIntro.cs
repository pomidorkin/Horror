using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LibraryIntro : MonoBehaviour
{
    [SerializeField] private PlayableDirector introCutscene;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private MouseLook mouseLook;

    private void OnEnable()
    {
        introCutscene.stopped += OnCutsceneFinishedHandler;
    }

    private void OnDisable()
    {
        introCutscene.stopped -= OnCutsceneFinishedHandler;
    }

    private void OnCutsceneFinishedHandler(PlayableDirector obj)
    {
        playerMovement.EnablePlayerMovement();
        mouseLook.EnableCameraMovement();
        // Disable evevator behind
    }

    void Start()
    {
        //MovePlayerIntro();
    }

    public void MovePlayerIntro()
    {
        introCutscene.Play();
    }
}
