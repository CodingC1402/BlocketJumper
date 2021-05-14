using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public SoundManager soundManager;

    [HideInInspector]
    public static MusicManager instance;
    private int currentIndex = 0;
    private bool startPlaying = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            currentIndex = DateTime.Now.Second % soundManager.sounds.Length;
            instance = this;
        }
    }

    public void StartPlaying()
    {
        startPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
            return;

        if (!soundManager.isPlayingSound)
        {
            PlayNextSong();
        }
    }

    public void PlayNextSong()
    {
        soundManager.PlaySound(currentIndex);
        currentIndex++;

        currentIndex %= soundManager.sounds.Length;
    }
}
