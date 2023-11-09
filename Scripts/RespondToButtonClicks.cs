using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RespondToButtonClicks : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        MenuLoader.GoToMenu(MenuName.Play);
    }
    public void HandleRetryButtonOnClickEvent()
    {
        MenuLoader.GoToMenu(MenuName.Main);
    }

    public void HandleExitButtonOnClickEvent()
    {
        Application.Quit();
    }
}
