using UnityEngine;
using System.Collections.Generic;

public class Spike : MonoBehaviour
{
    public Collider2D col;
    public Animator animator;
    public bool isStatic = true;
    public int damage = 1;
    public float upTime = 1;
    public float downTime = 1;
    public float delayBeforeDisableCol = 0.25f;
    public float delayBeforeEnableCol = 0.15f;
    public float pushBackForce = 1;
    public float upwardForce = 1;

    public List<string> targetedTag = new List<string>();

    private List<GameObject> inHitZone = new List<GameObject>();
    private void Start()
    {
        if (!isStatic)
        {
            Down();
        }
    }
    private void Update()
    {
        foreach (GameObject obj in inHitZone)
        {
            Heath health = obj.GetComponent<Heath>();
            if (health != null)
            {
                if (!health.isImmune)
                {
                    Vector2 forceDir = obj.transform.position - gameObject.transform.position;
                    forceDir.Normalize();
                    Rigidbody2D rb = obj.gameObject.GetComponent<Rigidbody2D>();
                    forceDir.y += upwardForce;
                    rb.velocity += forceDir * pushBackForce;
                }

                health.DealDamage(damage);
            }
        }
    }
    void Up()
    {
        animator.SetBool("IsUp", true);
        Invoke("Down", upTime);
        Invoke("EnableCol", delayBeforeEnableCol);
        GetComponent<AudioSource>().Play();
    }
    void Down()
    {
        animator.SetBool("IsUp", false);
        Invoke("Up", downTime);
        Invoke("DisableCol", delayBeforeDisableCol);
    }
    void DisableCol()
    {
        col.enabled = false;
    }
    void EnableCol()
    {
        col.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (targetedTag.Contains(collision.gameObject.tag))
        {
            inHitZone.Add(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        inHitZone.Remove(collision.gameObject);
    }
}
