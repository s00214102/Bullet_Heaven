using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    Rigidbody2D body;

    Transform target;

    public float brakePower = 100;
    EnemyData data => GetComponent<EnemyData>();

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //data.moveSpeed = data.defaultMoveSpeed;
    }

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (data.canMove)
        {
            transform.up = target.position - transform.position;
            Chase();
        }
    }

    void Chase()
    {
        body.AddForce(transform.up * data.moveSpeed * Time.deltaTime, ForceMode2D.Force);
    }
}
