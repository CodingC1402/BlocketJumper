using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    //Move form point A to point B
    public GameObject pointA;
    public GameObject pointB;
    [Range(0, 1)]
    public float speed; // percent increase each frame
    public float delayBetweenEachTrip = 5;
    public List<string> ridableTags;
    public bool isMoveByDistance = false;
    public Vector2 distance;

    [HideInInspector]
    public bool isInDelay = false;
    bool isAtoB = true;
    Vector3 moveVector;
    [Range(0, 1)]
    float currentPercent = 0;

    private List<GameObject> passengers;
    private List<bool> isInside;

    private bool CheckRunning = false;
    private void Start()
    {
        passengers = new List<GameObject>();
        isInside = new List<bool>();

        if (isMoveByDistance)
        {
            pointA.transform.position = gameObject.transform.position;
            Vector3 pos = pointA.transform.position;
            pos.x += distance.x;
            pos.y += distance.y;
            pointB.transform.position = pos;
        }

        gameObject.transform.position = pointA.transform.position;
        moveVector = pointB.transform.position - pointA.transform.position;
        moveVector /= (1 / speed);
    }
    // Update is called once per frame
    void Update()
    {
        if (!CheckRunning && passengers.Count > 0)
        {
            StartCoroutine(CheckRidding());
        }


        if (isInDelay)
            return;

        gameObject.transform.position += moveVector + moveVector * Time.deltaTime;
        currentPercent += speed + speed * Time.deltaTime;
        if (currentPercent >= 1)
        {
            ReachDes();
        }
    }
    IEnumerator CheckRidding()
    {
        CheckRunning = true;

        while (passengers.Count > 0)
        {
            yield return new WaitForSeconds(0.025f);

            for (int i = 0; i < passengers.Count; i++)
            {
                if (isInside[i])
                {
                    isInside[i] = false;
                }
                else
                {
                    if (passengers[i].transform.parent == gameObject.transform)
                    {
                        passengers[i].transform.parent = null;
                    }
                    passengers.RemoveAt(i);
                    isInside.RemoveAt(i);
                    i--;
                }
            }
        }

        CheckRunning = false;
    }
    void ReachDes()
    {
        if (isAtoB)
        {
            gameObject.transform.position = pointB.transform.position;
            moveVector = pointA.transform.position - pointB.transform.position;

        }
        else
        {
            gameObject.transform.position = pointA.transform.position;
            moveVector = pointB.transform.position - pointA.transform.position;
        }

        isAtoB = !isAtoB;
        currentPercent = 0;
        moveVector /= (1 / speed);
        isInDelay = true;
        Invoke("StopDelay", delayBetweenEachTrip);
    }
    void StopDelay()
    {
        isInDelay = false;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (ridableTags.Contains(collision.gameObject.tag))
        {
            if (!passengers.Contains(collision.gameObject))
            {
                passengers.Add(collision.gameObject);
                collision.gameObject.transform.parent = gameObject.transform;
                isInside.Add(true);
            }
            else
            {
                isInside[passengers.IndexOf(collision.gameObject)] = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (passengers.Contains(collision.gameObject))
        {
            if (collision.gameObject.transform.parent == gameObject.transform)
            {
                collision.gameObject.transform.parent = null;
            }
            isInside.RemoveAt(passengers.IndexOf(collision.gameObject));
            passengers.Remove(collision.gameObject);
        }
    }
}
