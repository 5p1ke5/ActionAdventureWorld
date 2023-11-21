using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }
<<<<<<< HEAD
    public GameObject menuTreeGameObject;
    // public static MenuBehavior menuBehavior;
    // Start is called before the first frame update

    private bool startHasBeenCalled;

    private void Awake()
    {

    }

    private void Start()
    {
        MenuBehavior.menuTree = menuTreeGameObject;
        Debug.Log("gamecontroller timescale is: " + Time.timeScale);

        

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
                    Debug.Log("gamecontroller timescale is: " + Time.timeScale);

                    GameObject startMenu = MenuBehavior.ReturnMenuGameObject("StartMenu");
                    MenuBehavior.EnableMenu(startMenu);
                    Debug.Log("gamecontroller timescale is: " + Time.timeScale);

                    Debug.Log("cursor.lockstate = " + Cursor.lockState +
                    "\nCursor.visible = " + Cursor.visible);

                    Debug.Log("scene is: " + currentScene);
                    break;
                case "CityLevel":
                    Debug.Log("scene is: " + currentScene);
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
            startHasBeenCalled = false;


        }


    }
    // Update is called once per frame
=======
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
>>>>>>> 9b4202a75fc4f514e3b5459b4671e7c88bf6fac4
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)&& Time.timeScale ==1)
        {
            GameObject pauseMenu = MenuBehavior.ReturnMenuGameObject("PauseMenu");
            MenuBehavior.ToggleMenu(pauseMenu);

        }
    }
}
