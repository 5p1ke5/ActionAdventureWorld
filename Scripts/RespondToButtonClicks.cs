using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespondToButtonClicks : MonoBehaviour
{
    MenuBehavior menu = new MenuBehavior();//not sure if this is right but it works
    

    public void HandlePlayButtonOnClickEvent()
    {
        //MenuLoader.GoToMenu(MenuName.Play);
        //GameObject buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        SceneManager.LoadScene("Game");
        //menu.DisableMenu(buttonClicked);
    }
    public void HandleRetryButtonOnClickEvent()
    {
        GameObject buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //MenuLoader.GoToMenu(MenuName.Main);

        menu.DisableMenu(buttonClicked);
    }
    public void HandleResumeButtonOnClickEvent()
    {
        GameObject buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //MenuLoader.GoToMenu(MenuName.Main);

        menu.DisableMenu(buttonClicked);
    }

    public void HandleExitButtonOnClickEvent()
    {
        Application.Quit();
    }

}
