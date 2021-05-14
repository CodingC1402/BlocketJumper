using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public float animationDelay = 0.5f;
    public TransitionUI transitionUI;

    public void LoadNextScene()
    {
        LoadSceneWithIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadSceneWithIndex(int index)
    {
        transitionUI.PlayStartAnimation();
        StartCoroutine(StartLoadScene(index));
    }
    IEnumerator StartLoadScene(int index)
    {
        yield return StartCoroutine(MyUtils.WaitForSecondWithoutTimeScale(animationDelay));
        SceneManager.LoadScene(index);
    }
}
