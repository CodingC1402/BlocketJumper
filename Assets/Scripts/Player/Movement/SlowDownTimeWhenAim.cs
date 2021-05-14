using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTimeWhenAim : MonoBehaviour
{
    [Range(0, 1)]
    public float slowDownTime = 0.5f;
    public Joystick aimmingJoyStick;
    private float fixedDeltaTime;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (aimmingJoyStick.Direction != Vector2.zero)
        {
            Time.timeScale = slowDownTime;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
        else
        {
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }
}
