using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public Heath health;
    public GameObject explosionEffect;
    public List<string> target;

    public void Update()
    {
        if (health.isDead)
        {
            GameObject effect = Instantiate(explosionEffect);
            effect.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (target.Contains(collision.gameObject.tag))
        {
            health.InstaDealth();
        }
    }
}
