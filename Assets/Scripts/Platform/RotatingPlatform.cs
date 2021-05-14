using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public float rotateSpeed;

    public void Update()
    {
        Vector3 rotation = gameObject.transform.eulerAngles;
        rotation.z += rotateSpeed * Time.deltaTime;
        gameObject.transform.eulerAngles = rotation;
    }
}
