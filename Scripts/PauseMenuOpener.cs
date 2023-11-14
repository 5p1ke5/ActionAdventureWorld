using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuOpener : MonoBehaviour
{
    public GameObject menuTree;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            GameObject pauseMenu = menuTree.transform.Find("PauseMenu").gameObject;
            pauseMenu.SetActive(true);
        }
    }
}
