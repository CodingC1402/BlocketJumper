using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    public Sound[] sounds;
    public GameObject source;

    [HideInInspector]
    public AudioSource playingSound = null;
    [HideInInspector]
    public bool isPlayingSound = false;

    // Update is called once per frame
    void Awake()
    {
        if (source == null)
            source = gameObject;

        foreach (Sound sound in sounds)
        {
            sound.source = source.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volumn;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;

            if (sound.audioMixerGroup == null)
            {
                sound.audioMixerGroup = audioMixerGroup;
            }
            sound.source.outputAudioMixerGroup = sound.audioMixerGroup;
        }
    }
    private void Update()
    {
        if (playingSound == null)
            return;

        if (!playingSound.isPlaying)
        {
            isPlayingSound = false;
            playingSound = null;
        }
    }
    public void SetVolumn(string name, float value)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            sound.source.volume = value;
            sound.volumn = value;
        }
        else
        {
            Debug.Log($"No sound called {name} exist");
        }
    }
    public void PlaySound(string name)
    {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound != null)
        {
            if (sound.source.isPlaying)
            {
                sound.source.Stop();
            }
            sound.source.Play();
            playingSound = sound.source;
            isPlayingSound = true;
        }
        else
        {
            Debug.Log($"No sound called {name} exist");
        }
    }
    public void PlaySound(int index)
    {
        if (index >= sounds.Length)
            return;

        Sound sound = sounds[index];
        if (sound != null)
        {
            if (sound.source.isPlaying)
            {
                sound.source.Stop();
            }

            sound.source.Play();
            playingSound = sound.source;
            isPlayingSound = true;
        }
        else
        {
            Debug.Log($"No sound with called {name} exist");
        }
    }
}
