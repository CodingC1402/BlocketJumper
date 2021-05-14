using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectWithDelay : MonoBehaviour
{
    public float delayOnDestroy = 0.2f;

    void Start()
    {
        Invoke("DestroyGameObject", delayOnDestroy);
    }
    private void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
