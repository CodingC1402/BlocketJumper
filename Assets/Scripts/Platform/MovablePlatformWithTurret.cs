using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatformWithTurret : MonoBehaviour
{
    public Turret[] turrets;
    public MovablePlatform platform;

    private bool isTurnOff = false;
    public void Update()
    {
        if (platform.isInDelay)
        {
            if (isTurnOff)
                return;

            isTurnOff = true;
            foreach(Turret turret in turrets)
            {
                turret.TurnOff();
            }
        }
        else
        {
            if (!isTurnOff)
                return;

            isTurnOff = false;
            foreach (Turret turret in turrets)
            {
                turret.TurnOn();
            }
        }
    }
}
