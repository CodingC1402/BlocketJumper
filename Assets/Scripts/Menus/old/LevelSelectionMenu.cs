using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionMenu : MonoBehaviour
{
    public AnimationMenuScript menuScript;
    public GameObject difSelectionPanel;
    PlayerData currentPlayerData;
    public LevelButton[] levels;
    public SceneLoader sceneLoader;

    public void Start()
    {
        UpdateLevelButtons();
    }
    public void OnEnable()
    {
        UpdateLevelButtons();
    }
    public void UpdateLevelButtons()
    {
        currentPlayerData = SaveLoad.CurrentPlayer;

        if (currentPlayerData == null)
        {
            SaveLoad.Load();
            currentPlayerData = SaveLoad.CurrentPlayer;

            if (currentPlayerData == null)
            {
                SaveLoad.Reset(true);
                currentPlayerData = SaveLoad.CurrentPlayer;
            }
        }    

        LevelData currentLevel;
        for (int i = 0; i < levels.Length; i++)
        {
            currentLevel = currentPlayerData.GetLevel(i);
            if (currentLevel != null)
            {
                if (!currentLevel.IsLocked)
                {
                    levels[i].Unlock();
                    levels[i].SetTrophy(currentLevel.Difficulty);
                    levels[i].SetTime(currentLevel.Min, currentLevel.Sec);
                }
                else
                {
                    levels[i].Lock();
                    levels[i].SetTrophy(-1);
                    levels[i].SetTime(0, 0);
                }
            }
        }
    }
    public void SaveLevel(int index, int min, int sec, int dif)
    {
        LevelData currentLevel = currentPlayerData.GetLevel(index);
        currentLevel.Min = min;
        currentLevel.Sec = sec;
        currentLevel.Difficulty = dif;
    }

    public void SelectLevel(int index)
    {
        menuScript.GoToDif();
        if (difSelectionPanel != null)
        {
            difSelectionPanel.GetComponent<DifSelectionPanel>().SetSelectedLevel(index);
        }
        else
            Debug.LogError("difSelectionPanel is null");
    }
    public void GoToCredit()
    {
        if (sceneLoader == null)
        {
            Debug.Log("Scene loader missing at level selection");
        }
        else
        {
            sceneLoader.LoadSceneWithIndex(difSelectionPanel.GetComponent<DifSelectionPanel>().startOfLevelIndex + levels.Length);
        }
    }
}
