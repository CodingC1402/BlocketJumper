using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour
{
    public Animator animator;
    public float inertia = 0.3f;
    public float delayBeforeIdle = 1f;
    public float tiltAngle = 7.5f;
    public float maxVerlocityToTilt = 1f;

    [HideInInspector]
    public float verlocityX;
    [HideInInspector]
    public float verlocityY;

    private float delayTime = 0;
    private Vector3 oldPoint;

    private void Start()
    {
        oldPoint = gameObject.transform.position;
    }
    void Update()
    {
        Vector3 verlocity = gameObject.transform.position - oldPoint;
        oldPoint = gameObject.transform.position;

        verlocityX = (1 - inertia - Time.deltaTime) * verlocityX + verlocity.x * (inertia + Time.deltaTime);
        verlocityY = (1 - inertia - Time.deltaTime) * verlocityY + verlocity.y * (inertia + Time.deltaTime);

        Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.z = -Mathf.Clamp(verlocityX / maxVerlocityToTilt, -1, 1) * tiltAngle;
        gameObject.transform.eulerAngles = rotation;

        animator.SetFloat("YAxisSpeed", verlocityY);
        animator.SetFloat("Speed", verlocityX);

        if (verlocity.magnitude > 0)
        {
            delayTime = delayBeforeIdle;
            animator.SetBool("ToIdle", false);
        }
        else
        {
            delayTime -= Time.deltaTime;
            if (delayTime <= 0)
            {
                animator.SetBool("ToIdle", true);
            }
        }
    }
}
