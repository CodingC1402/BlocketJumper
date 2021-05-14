using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : NormalBullets
{
    public GameObject explosionEffect;
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (ignore)
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else
        {
            if (!isHit)
            {
                Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
                isHit = true;
            }
        }
    }
}
