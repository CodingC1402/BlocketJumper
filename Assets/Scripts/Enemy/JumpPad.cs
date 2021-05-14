using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector]
    public bool isExpanded = false;
    public float jumpPadForce = 10;
    public Animator animator;
    public float delay = 0.25f;
    public List<string> targets;

    // Update is called once per frame
    Rigidbody2D collidedRB;
    Vector2 forceVector;
    private void Start()
    {
        forceVector = Vector2.up;
        forceVector = transform.rotation * forceVector;
    }
    void Update()
    {
        if (isExpanded && !animator.GetBool("Expand"))
        {
            isExpanded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isExpanded == true)
        {
            return;
        }

        if (targets.Contains(collision.gameObject.tag))
        {
            collidedRB = collision.gameObject.GetComponent<Rigidbody2D>();
            Invoke("AddForce", delay);
            isExpanded = true;
            animator.SetBool("Expand", true);
        }
    }

    void AddForce()
    {
        collidedRB.velocity += forceVector * jumpPadForce;
    }
}
