using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    public AudioMixerGroup audioMixerGroup;
    [Range(0, 1)]
    public float volumn = 1;
    [Range(-0.1f, 3f)]
    public float pitch = 1;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
