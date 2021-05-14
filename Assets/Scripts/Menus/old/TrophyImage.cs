using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyImage : MonoBehaviour
{
    public Image trophy;
    public Sprite[] trophies;
    void Start()
    {
        UpdateSprite();
    }

    public void UpdateSprite()
    {
        trophy.sprite = trophies[Difficulty.Value];
    }
}
