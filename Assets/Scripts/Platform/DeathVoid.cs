using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathVoid : MonoBehaviour
{
    public List<string> targetedTag;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetedTag.Contains(collision.tag))
        {
            Heath heath = collision.gameObject.GetComponent<Heath>();
            if (heath != null)
                heath.InstaDealth();
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
