using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameLoader : MonoBehaviour
{
    public MusicManager musicManager;
    public SceneLoader sceneLoader;
    public AudioMixer audioMixer;
    public float delayBeforeLoadSound = 0.5f;
    public float delayBeforeLoadNextScene = 0.5f;

    public void Start()
    {
        SaveLoad.Load();
        StartCoroutine(LoadStuff());
        SceneManager.sceneLoaded += (s, e) =>
        {
            Time.timeScale = 1;
        };
    }
    IEnumerator LoadStuff()
    {
        yield return new WaitForSecondsRealtime(delayBeforeLoadSound);
        Setting.audioMixer = audioMixer;
        Setting.Load();
        musicManager.StartPlaying();
        yield return new WaitForSecondsRealtime(delayBeforeLoadNextScene);
        sceneLoader.gameObject.SetActive(true);
        sceneLoader.LoadNextScene();
    }
}
