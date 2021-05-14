using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelTurret : MonoBehaviour
{
    public Animator animator;
    public GameObject explosionBarrel;
    public float delayBetweenSpawn = 5f;
    public AudioSource audio;

    private bool startSpawn = true;
    public void Update()
    {
        if (startSpawn)
        {
            StartCoroutine(spawnBarrel());
        }
    }

    IEnumerator spawnBarrel()
    {
        startSpawn = false;
        animator.SetTrigger("deploy");
        audio.Play();
        yield return new WaitForSeconds(0.5f);
        GameObject barrel = Instantiate(explosionBarrel);
        barrel.transform.position = gameObject.transform.position;

        animator.SetTrigger("retract");
        yield return new WaitForSeconds(delayBetweenSpawn + 0.5f);
        startSpawn = true;
    }
}
