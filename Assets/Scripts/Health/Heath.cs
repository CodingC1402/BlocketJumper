using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Heath : MonoBehaviour
{
    public GameObject damgedEffect;
    public int health = 10;
    public float immuneDuration = 0.5f;
    [HideInInspector]
    public bool isImmune = false;
    [HideInInspector]
    public bool isDead = false;
    public HealthBar healthBar;

    public string deathSoundName;
    public string damagedSoundName;
    public SoundManager soundManager;

    public void Awake()
    {
        if (healthBar != null)
        {
            healthBar.maxHealth = health;
            healthBar.currentHealth = health;
        }
    }
    public void DealDamage(int damage, bool ignoreImunity = false)
    {
        if (isImmune && !ignoreImunity)
            return;

        isImmune = true;

        if (healthBar != null)
        {
            healthBar.DealDamage(damage);
            health = healthBar.currentHealth;
        }
        else
        {
            health -= damage;
        }

        if (soundManager != null)
        {
            soundManager.PlaySound(damagedSoundName);
        }

        if (damgedEffect != null)
        {
            Instantiate(damgedEffect, gameObject.transform.position, gameObject.transform.rotation);
        }
        StartCoroutine(StopImmunity());
        if (health <= 0)
        {
            isDead = true;
            if (soundManager != null)
            {
                soundManager.PlaySound(deathSoundName);
            }
        }
    }

    public void InstaDealth()
    {
        DealDamage(999, true);
    }

    IEnumerator StopImmunity ()
    {
        yield return new WaitForSeconds(immuneDuration);
        isImmune = false;
    }
}
