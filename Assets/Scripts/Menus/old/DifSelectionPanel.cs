using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifSelectionPanel : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public int startOfLevelIndex = 3;

    int selectedLevel;
    public void SetSelectedLevel(int index)
    {
        selectedLevel = index;
    }

    public void StartLevel(int dif)
    {
        Difficulty.Value = dif;
        sceneLoader.LoadSceneWithIndex(startOfLevelIndex + selectedLevel);
    }
}

