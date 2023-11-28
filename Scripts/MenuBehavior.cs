using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour {
    public static GameObject menuTree;


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
        //        Debug.Log(MenuTree.transform.Find(CurrentMenuName).gameObject);
        //var currentMenu = MenuTree.transform.Find(CurrentMenuName).gameObject;

        //return to normal game state of mouse
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject parent = gameObj.transform.parent.gameObject;
        // GameObject currentMenuGO = parent.transform.Find(currentMenu).gameObject;
        Debug.Log(parent);
        Debug.Log("child " + gameObj);
        //Debug.Log("menugo " + currentMenuGO);

        parent.SetActive(false);

    }
    public static void ToggleMenu(GameObject gameObj)
    {

        
        Time.timeScale = (Time.timeScale == 1) ? 0 : 1;


        //return to normal game state of mouse
        if (Cursor.lockState == CursorLockMode.Locked)
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
        //Debug.Log("returnGaembject");
        //Debug.Log(ReturnMenuTree());
        return menuTree.transform.Find(menuElement).gameObject;

    }
    public static GameObject ReturnMenuTree()
    {
        return menuTree;
    }
}
