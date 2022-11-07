using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDude : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    public float speed = 100f;
    public float flyForce;
    public float flyCap;

    private void Start()
    {
        //InvokeRepeating
    }
    private void Update()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime, ForceMode2D.Force);

        if (flyForce < 100f)
        {
            flyForce++;
        }
        
        rb.AddForce(transform.up * flyForce * Time.deltaTime, ForceMode2D.Force);
    }

}
