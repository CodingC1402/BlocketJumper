using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider effectVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider masterVolumeSlider;

    public void OnEnable()
    {
        effectVolumeSlider.value = Setting.values.effectVolume;
        musicVolumeSlider.value = Setting.values.musicVolume;
        masterVolumeSlider.value = Setting.values.masterVolume;
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("masterVolume", MyUtils.GetdBFromValue(value));
    }
    public void SetEffectVolume(float value)
    {
        audioMixer.SetFloat("effectVolume", MyUtils.GetdBFromValue(value));

    }
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("musicVolume", MyUtils.GetdBFromValue(value));
    }
    public void ResetSaveFile()
    {
        Debug.Log("Reseting");
        SaveLoad.Reset();
    }

    public void SaveToSetting()
    {
        Setting.values.masterVolume = masterVolumeSlider.value;
        Setting.values.effectVolume = effectVolumeSlider.value;
        Setting.values.musicVolume = musicVolumeSlider.value;
        Setting.Save();
    }
}
