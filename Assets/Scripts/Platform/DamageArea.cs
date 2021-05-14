using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public List<string> targetedTag = new List<string>();
    public int damge = 1;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetedTag.Contains(collision.tag))
        {
            Heath heath = collision.gameObject.GetComponent<Heath>();
            if (heath != null)
            {
                heath.DealDamage(damge);
            }
        }
    }
}
