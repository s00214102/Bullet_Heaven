using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenOnDetection : MonoBehaviour
{
    public int Speed;
    public float range = 5f;
    Vector2 startingPosition;

    bool open = false;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    EnemyDetection Detect => GetComponent<EnemyDetection>();
    void Start()
    {
        startingPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (Detect.inRange)
        {
            open = true;
        }

        if (open)
        {
            OpenDoor();
        }
        else if (!open)
        {
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        if (GetDistance(startingPosition) < range)
        {
            rb.velocity = transform.up * Speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;

            if (!Detect.inRange)
            {
                open = false;
            }
        }
    }
    void CloseDoor()
    {
        if (Mathf.Abs(transform.position.y) > Mathf.Abs(startingPosition.y))
        {
            rb.velocity = transform.up * -1 * Speed * Time.deltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.position = startingPosition;
        }

        //check for when to stop
        //bool = false;
    }
    float GetDistance(Vector2 target)
    {
        return Vector2.Distance(target, transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);  
    }
}
