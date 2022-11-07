using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftCheckpointLid : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 openPosition;
    public float speed = 2f;
    public float playerDetectRange = 3f;
    public float lidOpenRange = 2f;
    Vector2 closedPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        closedPosition = transform.position;
    }
    public void OpenOrCloseForPlayer(float distance)
    {
        if (distance < playerDetectRange) //within range
        {
            OpenLid();

        }
        else
        {
            CloseLid();
        }
    }

    private void OpenLid()
    {
        //LiftLid();
        if (GetDistance(closedPosition) < lidOpenRange) //distance to target is greater than 0
        {
            //move up
            //print("trying to move up");
            rb.velocity = new Vector2(0, 1 * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void CloseLid()
    {
        //LowerLid();
        if (transform.position.y > closedPosition.y) //distance to target is greater than 0
        {
            //move down
            //print("trying to move down");
            rb.velocity = new Vector2(0, -1 * speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = Vector2.zero;
            transform.position = closedPosition;
        }
    }

    float GetDistance(Vector2 target)
    {
        return Vector2.Distance(target, transform.position);
    }
}
