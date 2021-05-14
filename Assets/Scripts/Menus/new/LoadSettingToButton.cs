using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettingToButton : MonoBehaviour
{
    public buttonSetting[] buttonSettings;
    public GameObject settingPanel;
    public SceneLoader sceneLoader;
    public int menuIndex = 1;

    public void GoToMenu()
    {
        sceneLoader.LoadSceneWithIndex(menuIndex);
    }
    public void SaveSetting()
    {
        for (int i = 0; i < buttonSettings.Length; i++)
        {
            Setting.SetUiSetting(buttonSettings[i].setting, i);
        }
        Setting.Save();
    }
    public void Awake()
    {
        if (settingPanel != null)
        {
            settingPanel.transform.position = new Vector2(0, Screen.height);
        }

        for (int i = 0; i < buttonSettings.Length; i++)
        {
            UISetting setting = Setting.GetUISetting(i);
            buttonSettings[i].setting = new UISetting();
            buttonSettings[i].setting.currentPosX = setting.currentPosX;
            buttonSettings[i].setting.currentPosY = setting.currentPosY;
            buttonSettings[i].setting.size = setting.size;
            buttonSettings[i].setting.transparence = setting.transparence;
        }
    }
}
