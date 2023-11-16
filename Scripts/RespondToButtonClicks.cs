using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespondToButtonClicks : MonoBehaviour
{

    
    public void HandlePlayButtonOnClickEvent()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
        //menu.DisableMenu(buttonClicked);
    }

    public void HandleRetryButtonOnClickEvent()
    {
        Time.timeScale = 1;
        //sad this was the problem the whole time
        SceneManager.LoadScene("Game");
        //GameObject buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        ////MenuLoader.GoToMenu(MenuName.Main);
        //GameObject menuObject = MenuBehavior.ReturnMenuGameObject(buttonClicked.transform.parent.name);
        //MenuBehavior.DisableMenu(menuObject);
    }

    public void HandleResumeButtonOnClickEvent()
    {
        GameObject buttonClicked = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //MenuLoader.GoToMenu(MenuName.Main);
        GameObject menuObject =MenuBehavior.ReturnMenuGameObject(buttonClicked.transform.parent.name);
        MenuBehavior.ToggleMenu(menuObject);
    }

    //this is getting axed at some point
    public void HandleExitButtonOnClickEvent()
    {
        Application.Quit();
    }

}
