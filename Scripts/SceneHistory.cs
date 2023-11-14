using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHistory : MonoBehaviour
{
    private List<string> sceneHistory = new List<string>();  //running history of scenes
                                                             //The last string in the list is always the current scene running

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);  //Allow this object to persist between scene changes
    }

    //Call this whenever you want to load a new scene
    //It will add the new scene to the sceneHistory list
    public void addToSceneHistory(string newScene)
    {
        sceneHistory.Add(newScene);
    }

    //Call this whenever you want to load the previous scene
    //It will remove the current scene from the history and then load the new last scene in the history
    //It will return false if we have not moved between scenes enough to have stored a previous scene in the history
    public string ReturnPreviousScene()
    {
        bool returnValue = false;
        //start menu + main game
        if (sceneHistory.Count >= 2)  //Checking that we have actually switched scenes enough to go back to a previous scene
        {
            returnValue = true;
            sceneHistory.RemoveAt(sceneHistory.Count - 1);
            return sceneHistory[sceneHistory.Count - 1];
        }
        else
        {
            Debug.Log("Somehting is wrong");
            return "";
        }

        
    }
}
