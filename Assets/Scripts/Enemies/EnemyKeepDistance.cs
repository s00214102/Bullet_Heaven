using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKeepDistance : MonoBehaviour
{
    [HideInInspector] public GameObject target;
    public Transform spriteTransform;
    int direction = 1;

    [SerializeField] float startRange;
    [SerializeField] bool inStartRange = false;

    [SerializeField]float stopRange;
    [SerializeField]bool inStopRange = false;

    Rigidbody2D body;
    EnemyData data;
    float speed;


    void Awake()
    {
        data = GetComponent<EnemyData>();
        body = GetComponent<Rigidbody2D>();
        //data.moveSpeed = data.defaultMoveSpeed;
        speed = data.moveSpeed;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CheckStopRange();
        CheckStartRange();
        DirectionToFace();

        if(data.canMove && inStartRange)
        {
            MoveToStopRange();
        }

    }
    private void MoveToStopRange()
    {
        if (!inStopRange)
        {
            Vector2 moveDirection = target.transform.position - transform.position;

            body.velocity = moveDirection * speed * Time.deltaTime;
        }
    }
    private void CheckStopRange()
    {
        if (GetDistance() < stopRange)
        {
            inStopRange = true;
        }
        else{ inStopRange = false;}
    }
    private void CheckStartRange()
    {
        if (GetDistance() < startRange)
        {
            inStartRange = true;
        }
        else{ inStartRange = false;}
    }
    void DirectionToFace()
    {
        if(target.transform.position.x < transform.position.x)
        {
            FlipSpriteLeft();
            direction = -1;
        }
        else if (target.transform.position.x > transform.position.x)
        {
            FlipSpriteRight();
            direction = 1;
        }
    }
    void FlipSpriteLeft()
    {
        if(direction == 1)
        {
            spriteTransform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void FlipSpriteRight()
    {
        if (direction == -1)
        {
            spriteTransform.localScale = new Vector3(1, 1, 1);
        }
    }
    float GetDistance()
    {
        return Vector2.Distance(target.transform.position, transform.position);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, startRange);
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
