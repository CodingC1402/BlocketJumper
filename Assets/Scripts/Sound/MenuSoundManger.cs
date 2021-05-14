using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManger : MonoBehaviour
{
    public SoundManager soundManager;
    public static MenuSoundManger instance;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public static void PlayNewRecordUISound()
    {
        instance.soundManager.PlaySound("newRecordSound");
    }
    public static void PlayVictoryUISound()
    {
        instance.soundManager.PlaySound("victorySound");
    }
    public static void PlayButtonClick()
    {
        instance.soundManager.PlaySound("buttonClick");
    }
    public static void PlayStartTransition()
    {
        instance.soundManager.PlaySound("startTransition");
    }
    public static void PlayEndTransition()
    {
        instance.soundManager.PlaySound("endTransition");
    }
}
