using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
    public GameObject menuTreeGameObject;
   // public static MenuBehavior menuBehavior;
    // Start is called before the first frame update
    private void Start()
    {
        //Debug.Log("gamecontroller timescale is: " + (Time.timeScale == 1 ? 1 : 0));

        
      
        MenuBehavior.menuTree = menuTreeGameObject;
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Game":

                //this right here is tweaking for some reason it has to do with update i believe because if i do the exact same thing in update this works

                //GameObject startMenu = MenuBehavior.ReturnMenuGameObject("StartMenu");
                //MenuBehavior.ToggleMenu(startMenu);

                Debug.Log("scene is: " + currentScene);
                break;
            case "CityLevel":
                Debug.Log("scene is: " +currentScene);
                break;
            case "IceLevel":
                Debug.Log("scene is: " + currentScene);
                break;
            case "ScoccerLevel":
                Debug.Log("scene is: " + currentScene);
                break;
            case "WaterLevel":
                Debug.Log("scene is: " + currentScene);
                break;
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
