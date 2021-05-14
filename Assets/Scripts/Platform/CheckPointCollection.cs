using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheckPointCollection : MonoBehaviour
{
    public CheckPoint[] checkPoints;
    public Vector2 offsetRespawn = Vector2.zero;
    public SoundManager soundManager;

    private CheckPoint currentCheckPoint;

    public Vector3 getCheckPointPosition()
    {
        if (currentCheckPoint != null)
        {
            Vector3 pos = currentCheckPoint.transform.position;
            pos.x += offsetRespawn.x;
            pos.y += offsetRespawn.y;
            return pos;
        }
        else
        {
            Debug.LogError("can't find currentCheckPoint");
            return Vector3.zero;
        }
    }

    public void SelectNewCheckPoint(CheckPoint checkPoint)
    {
        if (currentCheckPoint == checkPoint)
            return;

        if (currentCheckPoint != null)
        {
            currentCheckPoint.Unselect();
        }

        currentCheckPoint = checkPoint;
        soundManager.PlaySound(0);
        Debug.Log("Set Check Point");
    }
}
