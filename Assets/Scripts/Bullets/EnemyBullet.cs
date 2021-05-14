using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : NormalBullets
{
    public GameObject explodeEffect;
    public GameObject effectPoint;
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
                Instantiate(explodeEffect, effectPoint.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
                isHit = true;
            }
        }
    }
}
