using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    static string fileName = "player.dat";
    static PlayerData currentPlayer = null;
    public static PlayerData CurrentPlayer
    { 
        get 
        { 
            if (currentPlayer != null)
            {
                return currentPlayer;
            }
            else
            {
                Debug.LogError("Load save file first");
                return null;
            }
        }
    }

    public static void Save()
    {
        MyUtils.Save(fileName, CurrentPlayer);
    }
    public static void Load()
    {
        if (currentPlayer != null)
            return;

        try
        {
            currentPlayer = (PlayerData)MyUtils.Load(fileName);
            currentPlayer.UpdateSaveFile();
            if (currentPlayer.levels.Count > PlayerData.numberOfLevel)
            {
                Reset(true);
            }
        }
        catch
        {
            Reset(true);
        }

        if (currentPlayer == null)
        {
            Reset(true);
        }
    }

    public static void Reset(bool isDeleteAll = false)
    {
        if (isDeleteAll)
        {
            Debug.Log("Hard reset save file");
            currentPlayer = new PlayerData();
        }
        else
        {
            PlayerData oldData = currentPlayer;
            currentPlayer = new PlayerData();
            for (int i = 0; i < PlayerData.numberOfLevel; i++)
            {
                currentPlayer.GetLevel(i).IsLocked = oldData.GetLevel(i).IsLocked;
            }
        }
        MyUtils.Delete(fileName);
        Save();
    }
}
