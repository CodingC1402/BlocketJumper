using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public int uiSettingIndex = 2;
    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void GoToUISettingScene()
    {
        sceneLoader.LoadSceneWithIndex(2);
    }
}
