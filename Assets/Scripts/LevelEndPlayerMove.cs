using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPlayerMove : MonoBehaviour
{
    //move player clone to center of the level finish 

    public Transform destination; //set this from player collisions when the player clone is made
    public bool canMove = false; //after the destination is set, change bool to true
    public float speed = 100f;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private void Update()
    {
        if (canMove)
        {
            Vector2 direction = destination.position - transform.position;
            rb.velocity = direction * speed * Time.deltaTime;
        }
    }
}
