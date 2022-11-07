using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintVelocity : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private void Update()
    {
        print(rb.velocity.magnitude);
    }
}
