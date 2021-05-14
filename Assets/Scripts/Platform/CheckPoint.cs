using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public CheckPointCollection collection;
    public string targetedTag = "Player";

    private bool selected = false;
    private Animator animator;
    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Can't find animator on checkpoint");
        }
    }
    public void Select()
    {
        if (selected)
            return;

        selected = true;
        collection.SelectNewCheckPoint(this);
        animator.SetTrigger("trigger");
    }
    public void Unselect()
    {
        if (!selected)
            return;

        selected = false;
        animator.SetTrigger("trigger");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("SetCheckPoint");
        if (collision.gameObject.tag == targetedTag)
        {
            Select();
        }
    }
}
