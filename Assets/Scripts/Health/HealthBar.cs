using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearths;

    [Range(1, 10)]
    public int maxHealth;
    public int currentHealth;

    public Sprite fullHearth;
    public Sprite emptyHearth;

    public void DealDamage(int dmg)
    {
        currentHealth -= dmg;
        UpdateHealthBar();
    }
    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        currentHealth = value;
        UpdateHealthBar();
    }
    public void ChangeMaxHealth(int delta)
    {
        maxHealth += delta;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        if (maxHealth > hearths.Length)
            maxHealth = hearths.Length;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth < 0)
            currentHealth = 0;

        for (int i = 0; i < hearths.Length; i++)
        {
            if (i < maxHealth)
            {
                if (i < currentHealth)
                {
                    hearths[i].sprite = fullHearth;
                }
                else
                {
                    hearths[i].sprite = emptyHearth;
                }

                hearths[i].enabled = true;
            }
            else
            {
                hearths[i].enabled = false;
            }
        }
    }
}
