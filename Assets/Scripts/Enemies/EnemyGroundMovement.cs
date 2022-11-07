using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMovement : MonoBehaviour
{

    public float speed = 3;
    float direction = 1;
    Vector2 moveDirection;

    Rigidbody2D body;

    EnemyData data => GetComponent<EnemyData>();

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        this.transform.localScale = new Vector3(1, 1, 1);
        moveDirection = transform.up;
    }
    void Update()
    {
        if (data.canMove){ Movement(); }
    }
    private void FixedUpdate()
    {
        //DetectWall();
    }
    private void Movement()
    {
        body.velocity = new Vector2(speed * direction, body.position.y);
    }

    void FlipSprite()
    {
        if (direction == 1) //moving right
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction == -1) //moving left
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void FlipDirection()
    {
        if (direction == 1)
        {
            direction = -1;
        }
        else if (direction == -1)
        {
            direction = 1;
        }
    }
    void DetectWall()
    {
        Vector2 origin = new Vector2(this.transform.position.x + 0.5f, this.transform.position.y);
        
        RaycastHit2D hit = Physics2D.Raycast(origin, transform.forward, 0.6f);
        
        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            FlipDirection();
            FlipSprite();
        }
        
    }
    private void OnDrawGizmos()
    {
        Vector2 origin = new Vector2(this.transform.position.x +0.5f, this.transform.position.y);
        Debug.DrawRay(origin, transform.forward * 0.6f, Color.green);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.contactCount > 0)
    //    {
    //        FlipDirection();
    //        FlipSprite();
    //    }
    //}
}
