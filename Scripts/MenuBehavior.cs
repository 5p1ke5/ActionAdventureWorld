using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBehavior : MonoBehaviour
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
}
