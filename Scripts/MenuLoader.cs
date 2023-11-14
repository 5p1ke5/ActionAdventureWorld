﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuLoader 
{
    public static void GoToMenu(MenuName name)
    {
        switch (name)
        {
            case MenuName.Play:
                SceneManager.LoadScene("Game");
                break;
            case MenuName.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case MenuName.Lose:
                SceneManager.LoadScene("LoseMenu");
                break;
            case MenuName.Pause:
                SceneManager.LoadScene("PauseMenu");
                break;
            case MenuName.Resume:
                Time.timeScale = 1;
                break;
        }

    }
}
public enum MenuName
{
    Main,
    Lose,
    Play,
    Pause,
    Resume
}