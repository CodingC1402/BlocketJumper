using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    public ControllerMenu controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        Debug.Log("LevelFinished");
        controller.Win();
    }
}
