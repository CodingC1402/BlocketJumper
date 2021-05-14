using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersMovement : MonoBehaviour
{
    public GameObject asset;
    public Button dashButton;
    public Rigidbody2D rb;
    public FlipWithJoyStick flipScript;
    public float coolDown = 2;
    public float dashDuration = 1;
    public float dashSpeed = 3;

    [HideInInspector]
    public bool isDasing;
    Vector3 dashVector;
    float currentDashDuration = 0;

    Vector3 oldPos;
    float[] rbSetting = new float[4];bool isStartDash = true;
    void Start()
    {
        Time.timeScale = 1;
        oldPos = gameObject.transform.position;
        dashButton.coolDownTime = coolDown;
    }
    void FixedUpdate()
    {
        if (dashButton.isPressed)
        {
            if (isStartDash)
            {
                Dash();
            }
            isStartDash = false;
        }
        else
        {
            isStartDash = true;
        }

        if (isDasing)
        {
            MoveToDash();
        }
    }

    void Dash()
    {
        flipScript.isLocked = true;

        if (asset.transform.rotation.eulerAngles.y == 0)
        {
            dashVector = new Vector3(1, 0, 0);
        }
        else
        {
            dashVector = new Vector3(-1, 0, 0);
        }
        dashVector *= dashSpeed;

        isDasing = true;
        rb.velocity = Vector2.zero;

        rbSetting[0] = rb.mass;
        rbSetting[1] = rb.drag;
        rbSetting[2] = rb.angularDrag;
        rbSetting[3] = rb.gravityScale;

        rb.gravityScale = 0;
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.velocity = dashVector;

        currentDashDuration = dashDuration;
    }

    void MoveToDash()
    {
        if (currentDashDuration > 0)
        {
            currentDashDuration -= Time.deltaTime;
        }
        else
        {
            isDasing = false;

            flipScript.isLocked = false;
            rb.mass = rbSetting[0];
            rb.drag = rbSetting[1];
            rb.angularDrag = rbSetting[2];
            rb.gravityScale = rbSetting[3];
        }
    }
}
