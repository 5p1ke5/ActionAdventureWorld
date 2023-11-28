using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }


    public GameObject menuTreeGameObject;
    // public static MenuBehavior menuBehavior;

    private bool startHasBeenCalled;

    private void Start()
    {
        MenuBehavior.menuTree = menuTreeGameObject;

        startHasBeenCalled = true; 

    }

    private void OnGUI()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (startHasBeenCalled)
        {

            switch (currentScene)
            {
                case "Game":

                    //this right here is tweaking for some reason it has to do with update i believe because if i do the exact same thing in update this works
                    GameObject startMenu = MenuBehavior.ReturnMenuGameObject("StartMenu");
                    MenuBehavior.EnableMenu(startMenu);
                    break;
                case "CityLevel":
                    break;
                case "IceLevel":
                    break;
                case "SoccerLevel":
                    break;
                case "WaterLevel":
                    break;
            }
            startHasBeenCalled = false;


        }


    }
    // Update is called once per frame



    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)&& Time.timeScale ==1)
        {
            GameObject pauseMenu = MenuBehavior.ReturnMenuGameObject("PauseMenu");
            MenuBehavior.ToggleMenu(pauseMenu);

        }
    }
}
