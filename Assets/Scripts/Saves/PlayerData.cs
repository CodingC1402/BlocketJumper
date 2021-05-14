using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public class PlayerData
{
    public const int numberOfLevel = 6;
    public List<LevelData> levels;
    public LevelData GetLevel(int index)
    {
        if (index >= levels.Count)
        {
            return levels[levels.Count - 1];
        }

        return levels[index];
    }

    public PlayerData()
    {
        levels = new List<LevelData>();
        for(int i = 0; i < numberOfLevel; i++)
        {
            levels.Add(new LevelData());
        }

        if (numberOfLevel > 0)
        {
            levels[0].IsLocked = false;
        }
    }

    public void UpdateSaveFile()
    {
        for (int i = levels.Count; i < numberOfLevel; i++)
        {
            levels.Add(new LevelData());
        }
        levels[0].IsLocked = false;
    }
}

[Serializable]
public class LevelData
{
    bool isLocked = true;
    public bool IsLocked
    {
        get { return isLocked; }
        set
        {
            isLocked = value;
        }
    }

    int sec = 0;
    int min = 0;
    public int Sec
    {
        get { return sec; }
        set { sec = value; }
    }
    public int Min
    {
        get { return min; }
        set { min = value; }
    }

    int dif = -1;
    public int Difficulty
    {
        get { return dif; }
        set { dif = value; }
    }
}
