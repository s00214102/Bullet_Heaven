using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroundMoveWithWallDetect : MonoBehaviour
{

    float speed = 3;
    float direction = 1;
    Vector2 moveDirection;
    public LayerMask layer;
    [SerializeField]float rayLength = 1f;
    [SerializeField]float rayOriginDistance = 1f;

    Rigidbody2D body;

    EnemyData data => GetComponent<EnemyData>();

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        this.transform.localScale = new Vector3(1, 1, 1);
        //moveDirection = transform.up;

        speed = data.moveSpeed;
    }
    private void FixedUpdate()
    {
        DirectionDetection();
    }
    private void MoveRight()
    {
        //print("right");
        body.AddForce(transform.right*speed*Time.deltaTime, ForceMode2D.Force);
    }
    private void MoveLeft()
    {
        //print("left");
        body.AddForce((transform.right *-1)* speed * Time.deltaTime, ForceMode2D.Force);
    }
    void ChangeDirection()
    {
        if (direction == 1) //moving right
        {
            //this.transform.localScale = new Vector3(-1, 1, 1);
            direction = -1;
        }
        else if (direction == -1) //moving left
        {
            //this.transform.localScale = new Vector3(1, 1, 1);
            direction = 1;
        }
    }
    void DirectionDetection()
    {
        if (direction == 1)
        {
            if (data.canMove) { MoveRight(); }
            DetectRightWall();
        }
        else if (direction == -1)
        {
            if (data.canMove) { MoveLeft(); }
            DetectLeftWall();
        }
    }
    void DetectRightWall()
    {
        //Vector2 origin = new Vector2(this.transform.position.x + 0.6f, this.transform.position.y);
        Vector2 origin = (transform.position + transform.right * rayOriginDistance);

        RaycastHit2D hit = Physics2D.Raycast(origin, transform.right, rayLength, layer);

        if (hit.collider != null)
        {
            //print(hit.collider.gameObject.name);
            ChangeDirection();
        }
    }
    void DetectLeftWall()
    {
        //Vector2 origin = new Vector2(this.transform.position.x - 0.6f, this.transform.position.y);
        Vector2 origin = (transform.position + transform.right * -1 * rayOriginDistance);

        RaycastHit2D hit = Physics2D.Raycast(origin, transform.right*-1, rayLength, layer);

        if (hit.collider != null)
        {
            //print(hit.collider.gameObject.name);
            ChangeDirection();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (direction == 1)
        {
            Vector2 origin = (transform.position + transform.right *rayOriginDistance);
            //Vector2 origin = new Vector2(this.transform.position.x + 0.6f, this.transform.position.y);
            //Debug.DrawRay(origin, transform.right * rayLength, Color.green);

            Debug.DrawLine(origin, origin + Vector2.right * rayLength, Color.green);
        }
        else if (direction == -1)
        {
            Vector2 origin = (transform.position + transform.right * -rayOriginDistance);
            //Vector2 origin = new Vector2(this.transform.position.x - 0.6f, this.transform.position.y);
            //Debug.DrawRay(origin, transform.right *-rayLength, Color.green);

            Debug.DrawLine(origin, origin + Vector2.left * rayLength, Color.green);
        }
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
