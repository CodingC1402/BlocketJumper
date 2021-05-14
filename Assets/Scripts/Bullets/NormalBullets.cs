using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullets : MonoBehaviour
{
    public float bulletSpeed = 10;
    public Rigidbody2D rd;
    public string[] ignoreTags = { "Player", "Bullets", "Effects" };

    protected bool isHit = false;
    protected bool ignore = false;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = gameObject.transform.rotation;
        Vector3 vector = Vector3.right;
        vector = rotation * vector;
        Vector2 force = new Vector2(vector.x, vector.y);
        rd.velocity = force * bulletSpeed;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        ignore = false;
        foreach (string s in ignoreTags)
        {
            if (s == collision.gameObject.tag)
            {
                ignore = true;
            }
        }
    }
}
