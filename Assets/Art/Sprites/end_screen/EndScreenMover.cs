using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenMover : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public float speed = 100f;

    private void Update()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Force);
    }
}
