using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.Audio;
using UnityEngine;
using System;

public static class Setting
{
    public static float ratioRes = 1;
    public static Vector2 defaultRes = new Vector2(2160, 1080);
    private static string fileName = "setting.ini";
    public static SettingValue values = null;
    public static AudioMixer audioMixer;

    // Start is called before the first frame update
    public static void Save()
    {
        MyUtils.Save(fileName, values);
    }
    public static void Load()
    {
        if (values != null)
            return;

        bool isNewFile = false;
        try
        {
            values = (SettingValue)MyUtils.Load(fileName);
            if (values.settings.Length == 0 || values.screenWidth == 0 || values.screenHeight == 0)
            {
                values = null;
            }
        }
        catch
        {
            values = null;
        }

        if (values == null)
        {
            Debug.Log("Can't find save file");
            values = new SettingValue();
            Save();
            isNewFile = true;
        }

        audioMixer.SetFloat("masterVolume", MyUtils.GetdBFromValue(values.masterVolume));
        audioMixer.SetFloat("effectVolume", MyUtils.GetdBFromValue(values.effectVolume));
        audioMixer.SetFloat("musicVolume", MyUtils.GetdBFromValue(values.musicVolume));

        ratioRes = Screen.height / (float)Setting.defaultRes.y;
        float ratioOfFileAndScreenX;
        float ratioOfFileAndScreenY;
        if (isNewFile)
        {
            ratioOfFileAndScreenX = Screen.width / (float)Setting.defaultRes.x;
            ratioOfFileAndScreenY = ratioRes;
        }
        else
        {
            ratioOfFileAndScreenX = Screen.width / (float)values.screenWidth;
            ratioOfFileAndScreenY = Screen.height / (float)values.screenHeight;
        }

        Debug.Log($"{ratioOfFileAndScreenX}, {ratioOfFileAndScreenY}");
        for(int i = 0; i < values.settings.Length; i++)
        {
            values.settings[i].currentPosX *= ratioOfFileAndScreenX;
            values.settings[i].currentPosY *= ratioOfFileAndScreenY;
        }

        values.screenHeight = Screen.height;
        values.screenWidth = Screen.width;
    }
    public static UISetting GetUISetting(int index)
    {
        try
        {
            return values.settings[index];
        }
        catch
        {
            return null;
        }
    }
    public static void SetUiSetting(UISetting setting, int index)
    {
        try
        {
            values.settings[index] = setting;
        }
        catch
        {
            return;
        }
    }
}

[Serializable]
public class SettingValue
{
    public int screenWidth;
    public int screenHeight;
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float effectVolume = 1;
    public UISetting[] settings;

    public SettingValue()
    {
        settings = new UISetting[3];
        settings[0] = new UISetting();
        settings[0].currentPosX = settings[0].currentPosY = 252;

        settings[1] = new UISetting();
        settings[1].currentPosX = 1692;
        settings[1].currentPosY = 200;

        settings[2] = new UISetting();
        settings[2].currentPosX = 1980;
        settings[2].currentPosY = 200;

        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
}

