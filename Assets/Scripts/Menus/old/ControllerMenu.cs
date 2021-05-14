using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public GameObject normalUI;
    public GameObject victoryUI;
    public GameObject loseUI;
    public SceneLoader sceneLoader;
    public MainAsset asset;
    public Animator animator;
    public float delayForVictorySound = 0.25f;
    public float delayForNewRecord = 1.5f;
    public float delayForNewRecordSound = 0.17f;

    public void  Win()
    {
        Time.timeScale = 0;
        animator.SetTrigger("toVictory");
        StartCoroutine(PlayVictoryUISound());
    }
    IEnumerator PlayVictoryUISound()
    {
        yield return new WaitForSecondsRealtime(delayForVictorySound);

        MenuSoundManger.PlayVictoryUISound();
    }
    public void Lose()
    {
        Time.timeScale = 0;
        animator.SetTrigger("toLose");
    }

    public void RestoreTimeScale()
    {
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        sceneLoader.LoadSceneWithIndex(asset.MenuIndex);
    }
    public void RestartLevel()
    {
        Time.timeScale = 1;
        sceneLoader.LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex);
    }
    public void UIToPause()
    {
        animator.SetTrigger("toPause");
    }
    public void PauseToOption()
    {
        animator.SetTrigger("toOption");
    }
    public void IsNewRecord()
    {
        StartCoroutine(PlayNewRecordAnimation());
    }
    IEnumerator PlayNewRecordAnimation()
    {
        yield return new WaitForSecondsRealtime(delayForNewRecord);
        animator.SetTrigger("toNewRecord");
        yield return new WaitForSecondsRealtime(delayForNewRecordSound);
        MenuSoundManger.PlayNewRecordUISound();
    }
    public void GoBack()
    {
        animator.SetTrigger("back");
    }
}
