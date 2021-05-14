using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionUI : MonoBehaviour
{
    public Animator animator;
    public bool isDelayStart = false;
    public float delay = 0.5f;

    public void Start()
    {
        if (isDelayStart)
        {
            StartCoroutine(playAnimation());
        }
    }
    IEnumerator playAnimation()
    {
        yield return new WaitForSecondsRealtime(delay);
        PlayEndAnimation();
    }
    public void PlayStartAnimation()
    {
        animator.SetTrigger("startAnimation");
    }
    public void PlayEndAnimation()
    {
        animator.SetTrigger("endAnimation");
    }
}
