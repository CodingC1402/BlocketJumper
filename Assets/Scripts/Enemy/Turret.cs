using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bullet;
    public int roundEachFire = 1;
    public float delayBetweenRound = 0.2f;
    public float coolDownTime = 2;

    private bool isStopFiring = false;
    private bool isInCoolDown = false;
    public void Update()
    {
        if (isInCoolDown || isStopFiring)
            return;

        StartCoroutine(Firing());
    }

    IEnumerator Firing()
    {
        int rounds = 0;
        isInCoolDown = true;

        while (rounds < roundEachFire)
        {
            GetComponent<AudioSource>().Play();
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);

            yield return new WaitForSeconds(delayBetweenRound);
            rounds++;
        }

        yield return new WaitForSeconds(coolDownTime);
        isInCoolDown = false;
    }
    public void TurnOff()
    {
        isStopFiring = true;
    }
    public void TurnOn() // Get turn on OwO
    {
        isStopFiring = false;
    }
}
