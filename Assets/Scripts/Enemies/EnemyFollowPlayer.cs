using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    Rigidbody2D body;

    EnemyDetection detect;

    EnemyData data => GetComponent<EnemyData>();

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        detect = GetComponent<EnemyDetection>();

        data.moveSpeed = data.defaultMoveSpeed;
    }

    void Update()
    {
        if (detect.inRange)
        {
            transform.up = detect.target.transform.position - transform.position;

            //body.velocity = transform.up;
            body.AddForce(transform.up * data.moveSpeed, ForceMode2D.Force);
        }
        else
        {
            body.velocity = new Vector2(0, 0);
        }
    }
}
