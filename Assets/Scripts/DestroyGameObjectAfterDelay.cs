using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DestroyGameObjectAfterDelay : MonoBehaviour
{
    public Light2D lightSource;
    public int lightStep = 10;
    public float startUpSec = 0.2f;
    public float stayMaxSec = 0.2f;

    public float delay = 2;
    public bool dependOnTimeScale = true;

    private float lightIntensity;
    private float reduceEachLoop;
    private float delayBetweenLoop;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyGameObject());

        if (lightSource != null)
        {
            lightIntensity = lightSource.intensity;
            lightSource.intensity = 0;
            reduceEachLoop = lightIntensity / (float)lightStep;
            delayBetweenLoop = startUpSec / (float)lightStep;
            StartCoroutine(StartUpLight());
        }
    }
    IEnumerator StartUpLight()
    {
        while (lightSource.intensity < lightIntensity)
        {
            yield return new WaitForSeconds(delayBetweenLoop);
            lightSource.intensity += reduceEachLoop;
        }

        lightSource.intensity = lightIntensity;
        yield return new WaitForSeconds(stayMaxSec);
        delayBetweenLoop = Mathf.Clamp(delay - startUpSec - stayMaxSec, 0, 1) / (float)lightStep;
        StartCoroutine(ReduceLight());
    }
    IEnumerator ReduceLight()
    {
        while (lightSource.intensity > 0)
        {
            yield return new WaitForSeconds(delayBetweenLoop);
            lightSource.intensity -= reduceEachLoop;
        }
        lightSource.intensity = 0;
    }
    IEnumerator DestroyGameObject()
    {
        if (dependOnTimeScale)
        {
            yield return new WaitForSeconds(2);
        }
        else
        {
            yield return MyUtils.WaitForSecondWithoutTimeScale(2);
        }

        Destroy(gameObject);
    }
}
