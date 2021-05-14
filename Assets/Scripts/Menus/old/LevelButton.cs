using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public int level = 1;
    public LevelSelectionMenu levelSelectionMenu;
    public Image lockedOverlay;
    public Image trophy;
    public TextMeshProUGUI text;
    public TextMeshProUGUI cardName;

    /// <summary>
    /// In acs order in dif
    /// </summary>
    public Sprite[] trophies;

    void Awake()
    {
        text.text = $"0:00";
        trophy.enabled = false;
        //cardName.text = $"Level {level}";
    }
    public void SetTime(int min, int sec)
    {
        string stringSec = $"{sec}";
        stringSec = stringSec.PadLeft(2, '0');
        string stringMin = $"{min}";
        stringMin = stringMin.PadLeft(2, '0');
        text.text = $"{stringMin}:{stringSec}";
    }
    public void SetLevel()
    {
        if (levelSelectionMenu != null)
        {
            levelSelectionMenu.SelectLevel(level - 1);
        }
        else
        {
            Debug.LogError("levelSelectionMenu is null");
        }
    }
    public void SetTrophy(int dif)
    {
        if (dif >= trophies.Length)
        {
            Debug.Log("number of dif is higher than the normal");
            return;
        }

        if (dif < 0)
        {
            trophy.enabled = false;
        }
        else
        {
            trophy.enabled = true;
            trophy.sprite = trophies[dif];
        }
    }

    public void Unlock()
    {
        lockedOverlay.enabled = false;
    }

    public void Lock()
    {
        lockedOverlay.enabled = true;
    }
}
