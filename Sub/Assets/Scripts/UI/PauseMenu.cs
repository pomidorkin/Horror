using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] private bool test = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] FMODHighBypass bypassEffect;

    public class GamePausedEventArgs : EventArgs
    {
        public bool IsPaused { get; set; }
    }

    public delegate void GamePausedAction(object source, GamePausedEventArgs args);
    public event GamePausedAction OnGamePausedAction;


    private void Update()
    {
        if (test)
        {
            test = false;
            TogglePauseMenu();
        }
    }

    private void TogglePauseMenu()
    {
        OnGamePausedAction(this, new GamePausedEventArgs() { IsPaused = gameIsPaused });
        bypassEffect.PlayBypassEffect(!gameIsPaused);
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
