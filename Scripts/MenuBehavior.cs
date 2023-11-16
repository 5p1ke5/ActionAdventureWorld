using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
<<<<<<< HEAD
{
    public static GameObject menuTree;

    //void Update()
    //{
    //    if (gameObject.activeSelf)
    //    {
    //        Time.timeScale = 0;
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //    }
    //}
  
    public static void EnableMenu(GameObject gameObj)
    {
        Time.timeScale = 0;
        Debug.Log("Time Stopped");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        

        gameObj.SetActive(true);
        Debug.Log("MenuEnable");
    }

    public static void DisableMenu(GameObject gameObj)
    {
        
        //return to normal game state of mouse
        Time.timeScale = 1;
        Debug.Log("Time Started");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameObj.SetActive(false);
        Debug.Log("MenuDIsabled");

    }
    public static void ToggleMenu(GameObject gameObj)
    {

        //return to normal game state of mouse
        Time.timeScale = (Time.timeScale==1) ? 0 : 1;
        


        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        Cursor.visible = !Cursor.visible;

        gameObj.SetActive(!gameObj.activeSelf);
        Debug.Log("MenuToggled");

    }
    public static GameObject ReturnMenuGameObject(string menuElement)
    {
        Debug.Log("returnGaembject");
        Debug.Log(ReturnMenuTree());
        return menuTree.transform.Find(menuElement).gameObject;
       
    }
    public static GameObject ReturnMenuTree()
    {
        return menuTree;
    }
=======
{



    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void DisableMenu(GameObject gameObj)
    {
//        Debug.Log(MenuTree.transform.Find(CurrentMenuName).gameObject);
        //var currentMenu = MenuTree.transform.Find(CurrentMenuName).gameObject;
        
        //return to normal game state of mouse
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject parent = gameObj.transform.parent.gameObject;
       // GameObject currentMenuGO = parent.transform.Find(currentMenu).gameObject;
        Debug.Log(parent);
        Debug.Log("child " +gameObj);
        //Debug.Log("menugo " + currentMenuGO);

        parent.SetActive(false);

    }
>>>>>>> 6346c1b3cf20406753d6c641028f6bfaf29c7ebe
}
