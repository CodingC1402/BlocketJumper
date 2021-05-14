using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScripte : MonoBehaviour
{
    public float timeDelay = 0;
    public float explosionForce = 10;
    public float explosionRadius = 5;
    [Range(0, 1)]
    public float forceCap = 1;
    public float upwardForce = 0.0f;
    public int damage = 0;

    // Apply force the these tags
    public string[] targetedTags = { "Player", "Enemies" };

    // Deal damge to these tags
    public string[] damgeTags = { "Player", "Enemies" };

    private List<Rigidbody2D> ignoreRB = new List<Rigidbody2D>();
    private bool stop = false;
    void Start()
    {
        Invoke("Stop", timeDelay);
    }
    void Stop()
    {
        stop = true;
    }
    private void FixedUpdate()
    {
        if (stop)
            return;

        Vector2 explosionPos = gameObject.transform.position;
        Collider2D[] collidedObj = Physics2D.OverlapCircleAll(explosionPos, explosionRadius);

        bool isDealDamge = false;
        bool isAppliedForce = false;
        bool isImmune = false;
        foreach (Collider2D obj in collidedObj)
        {
            isDealDamge = Contain(damgeTags, obj.tag);
            isAppliedForce = Contain(targetedTags, obj.tag);

            Heath heath = obj.GetComponent<Heath>();
            if (heath is null)
                isImmune = false;
            else
                isImmune = heath.isImmune;

            if (isAppliedForce)
            {
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (!(ignoreRB.Contains(rb) || (isImmune && isDealDamge)))
                {
                    ExpodeForce2D(rb, explosionForce, explosionPos, explosionRadius, upwardForce, ForceMode2D.Impulse);
                    ignoreRB.Add(rb);
                }
            }
            if (damage > 0 && isDealDamge)
            {
                if (heath != null)
                {
                    heath.DealDamage(damage);
                }
            }    
        }
    }
    bool Contain(string[] tags, string findTag)
    {
        bool isContain = false;
        foreach (string tag in tags)
        {
            if (tag == findTag)
            {
                isContain = true;
                break;
            }
        }
        return isContain;
    }
    void ExpodeForce2D(Rigidbody2D rb, float explosionForce, Vector2 explosionPosition, float explosionRadius, float upwardsModifier = 0.0F, ForceMode2D mode = ForceMode2D.Force)
    {
        var explosionDir = rb.position - explosionPosition;
        var explosionDistance = explosionDir.magnitude;

        if (upwardsModifier == 0)
        {
            explosionDir /= explosionDistance;
        }
        else
        {
            explosionDir.Normalize();
            explosionDir.y *= upwardsModifier;
        }

        // add cap to calculated force
        float trueExplosionForce = explosionForce * forceCap;
        rb.velocity += trueExplosionForce * explosionDir;
    }
}
