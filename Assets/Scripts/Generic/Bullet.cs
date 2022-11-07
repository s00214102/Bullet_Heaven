using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //-if the object doesnt have a rigidbody2d, this will give it one

public class Bullet : MonoBehaviour
{
    //-generic class used to propel bullets
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [HideInInspector]public float bulletSpeed;

    private void FixedUpdate()
    {
        //move the bullet
        rb.velocity = transform.up * bulletSpeed;
    }
}
