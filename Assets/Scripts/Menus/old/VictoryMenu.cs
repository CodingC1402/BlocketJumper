using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryMenu : MonoBehaviour
{
    public GameObject nextLevelButton;
    public Timer timer;
    public SceneLoader sceneLoader;
    public TextMeshProUGUI text;
    public ControllerMenu controller;

    public MainAsset asset;
    private void OnEnable()
    {
        string sSec = $"{timer.seconds}";
        sSec = sSec.PadLeft(2, '0');
        string sMin = $"{timer.minute}";
        sMin = sMin.PadLeft(2, '0');
        text.text = $"{sMin}:{sSec}";

        LevelData currentLevel = SaveLoad.CurrentPlayer.GetLevel(asset.LevelNumber - 1);
        Debug.Log($"{currentLevel.Difficulty}");
        bool isNewRecord = false;

        if (currentLevel.Difficulty < Difficulty.Value)
        {
            currentLevel.Difficulty = Difficulty.Value;
            currentLevel.Min = timer.minute;
            currentLevel.Sec = timer.seconds;

            isNewRecord = true;
        }
        else if (currentLevel.Difficulty == Difficulty.Value)
        {
            if (currentLevel.Min > timer.minute)
            {
                currentLevel.Min = timer.minute;
                currentLevel.Sec = timer.seconds;

                isNewRecord = true;
            }
            else if (currentLevel.Sec > timer.seconds)
            {
                currentLevel.Sec = timer.seconds;

                isNewRecord = true;
            }
        }

        if (isNewRecord)
        {
            controller.IsNewRecord();
        }

        if (asset.LevelNumber < PlayerData.numberOfLevel)
        {
            currentLevel = SaveLoad.CurrentPlayer.GetLevel(asset.LevelNumber);
            currentLevel.IsLocked = false;
            nextLevelButton.SetActive(true);
        }
        else
        {
            nextLevelButton.GetComponentInChildren<TextMeshProUGUI>().text = "Credit";
        }

        SaveLoad.Save();
    }
    public void NextLevel()
    {
        sceneLoader.LoadNextScene();
    }
}
