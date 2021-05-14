using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationMenuScript : MonoBehaviour
{
    public Image blockPanel;
    public float animationTime = 0.3f;
    public Animator animator;
    public GameObject[] disableOnLatterLoad;

    private static bool isFirstTime = false;
    public void Start()
    {
        if (isFirstTime)
        {
            foreach(GameObject obj in disableOnLatterLoad)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            isFirstTime = true;
        }
    }
    public void GoToLevelSelection()
    {
        StartCoroutine(SetTrigger("toLevel"));
    }
    public void GoToOption()
    {
        StartCoroutine(SetTrigger("toOption"));
    }
    public void GoBack()
    {
        StartCoroutine(SetTrigger("back"));
    }
    public void GoToDif()
    {
        StartCoroutine(SetTrigger("toDif"));
    }
    public void GoToResetPanel()
    {
        StartCoroutine(SetTrigger("toReset"));
    }
    public void GoToIntroduction()
    {
        StartCoroutine(SetTrigger("toIntroduction"));
    }
    IEnumerator SetTrigger(string trigger)
    {
        blockPanel.enabled = true;
        animator.SetTrigger(trigger);
        yield return new WaitForSecondsRealtime(animationTime);

        blockPanel.enabled = false;
    }
}
