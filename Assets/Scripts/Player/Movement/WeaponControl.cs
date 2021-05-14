using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public Joystick aimmingJoyStick;
    public Button fireButton;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Rigidbody2D playerRb;
    public float knockBackForce = 1;

    Vector2 anchor = new Vector2(0, 0);
    float currentAngle = 0;
    [Range(0, 1)]
    public float rotationSpeed = 1;

    public float fireRate = 2;
    private float fireCoolDown
    { 
        get
        {
            return 1 / fireRate;
        }
    }

    bool isShooted = false;
    private void Start()
    {
        fireButton.coolDownTime = fireCoolDown;
    }
    void Update()
    {
        Vector2 direction = new Vector2(Mathf.Abs(aimmingJoyStick.Direction.x), aimmingJoyStick.Direction.y);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (direction == anchor)
        {
            currentAngle = currentAngle * (1 - rotationSpeed) + angle * rotationSpeed;
        }
        else
        {
            currentAngle = angle;
        }

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, currentAngle);


        Shoot();
    }

    void Shoot()
    {
        if (fireButton.isPressed && !isShooted)
        {
            AudioSource sound = GetComponent<AudioSource>();
            sound.Play();

            Vector2 force = gameObject.transform.position - firePoint.transform.position;
            playerRb.AddForce(force * knockBackForce, ForceMode2D.Impulse);
            Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            isShooted = true;
        }
        else if (!fireButton.isPressed)
        {
            isShooted = false;
        }
    }
}
