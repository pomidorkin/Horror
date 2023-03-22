using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField] private bool test = false;
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] FMODHighBypass bypassEffect;
    PlyerInputActions plyerInputActions;

    public class GamePausedEventArgs : EventArgs
    {
        public bool IsPaused { get; set; }
    }

    public delegate void GamePausedAction(object source, GamePausedEventArgs args);
    public event GamePausedAction OnGamePausedAction;


    private void Awake()
    {
        plyerInputActions = new PlyerInputActions();
        plyerInputActions.Player.Enable();
        /// Player -> Action Map; Jump, Movement -> Actions; performed -> state
    }


    private void OnEnable()
    {
        plyerInputActions.Player.Pause.performed += TogglePauseMenu;
    }

    private void OnDisable()
    {
        plyerInputActions.Player.Pause.performed -= TogglePauseMenu;
    }

    private void TogglePauseMenu(InputAction.CallbackContext obj)
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


   /* private void TogglePauseMenu(InputAction.CallbackContext context)
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
    }*/

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
