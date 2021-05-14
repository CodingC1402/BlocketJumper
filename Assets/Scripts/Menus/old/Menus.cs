using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menus : MonoBehaviour
{
    public TransitionUI transition;
    public float transitionDuration;
    public GameObject parent;
    public GameObject[] children;

    public void GoToMenu(int index)
    {
        if (index < 0 || index >= children.Length)
        {
            return;
        }
        StartCoroutine(DisableAndEnable(gameObject, children[index]));
    }
    IEnumerator DisableAndEnable(GameObject disObj, GameObject enaObj)
    {
        if (transition != null)
        {
            transition.PlayStartAnimation();
        }

        yield return new WaitForSeconds(transitionDuration);

        disObj.SetActive(false);
        enaObj.SetActive(true);

        if (transition != null)
        {
            transition.PlayEndAnimation();
        }
    }
    public void GoBack()
    {
        StartCoroutine(DisableAndEnable(gameObject, parent));
    }
}
