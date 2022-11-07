using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFollow : MonoBehaviour
{
    public Transform target; //who to follow

    //public GameObject player;
    //Movement_custom_accel playerMovement;

    //Transform parentTransform;
    //Vector3 parentPosition;

    //Vector3 currentPlayerPosition;
    Vector3 currentTargetPosition;

    public float defaultSpeed = 300f;
    float currentSpeed;

    //public float deccelerationMultiplier = 0;
    //public float decelTime = 0;
    //float refVelocity = 0;
    //private Vector2 velocityRef = Vector2.zero;

    public float minDistance = 0.5f; //how close they will get to their target
    public float maxDistance = 2; //when over the max distance, give them a little speed boost

    [Range(1f, 5f)]
    public float speedBoost = 1.5f;

    public bool normalize = false;
    public bool forceMove = false;
    public bool minimumDistance = false;
    public bool copyTargetRotation = false;

    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerMovement = player.GetComponent<Movement_custom_accel>();

        currentSpeed = defaultSpeed;
    }
    void FixedUpdate()
    {
        if (target != null) //only try to move when the orb has a target
        {
            currentTargetPosition = target.transform.position;

            Vector2 direction = GetDirection(); //get direction to move in
            MoveOrb(direction);                 //move in that direction
            CatchUp();                          //apply a speed boost if lagging behind
            CopyRotation();
        }
    }
    public void StopOrb()
    {
        target = null;
        rb.velocity = new Vector2(0,0);
    }
    private Vector2 GetDirection()
    {
        //our position - the parents position is the direction to move in
        Vector2 direction = target.position - transform.position;

        if (normalize)
        {
            direction = direction.normalized;
        }

        return direction;
    }
    private void MoveOrb(Vector2 direction)
    {
        //adds force in the direction of the target
 
        if (forceMove)
        {
            rb.AddForce(direction * currentSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else
        {
            if (minimumDistance)
            {
                if (DistanceToTarget() > minDistance) //-only move if far enough away from target
                {
                    rb.velocity = direction * currentSpeed * Time.deltaTime;
                }
                else
                {
                    rb.velocity = new Vector2(0, 0);
                }
                return;
            }

            rb.velocity = direction * currentSpeed * Time.deltaTime;
        }
    }
    void CopyRotation()
    {
        if (copyTargetRotation)
        {
            transform.rotation = target.transform.rotation;
        }
    }
    private void CatchUp()
    {
        if (DistanceToTarget() > maxDistance) //if the distance is greater than max value, apply a speed boost
        {
            currentSpeed = defaultSpeed * speedBoost; //multiply starting speed by the multipier value
        }
        else if (DistanceToTarget() < maxDistance)
        {
            currentSpeed = defaultSpeed; //set speed back to starting value
        } 
    }

    private float DistanceToTarget() //-change to distance to target
    {
        return Vector2.Distance(transform.position, currentTargetPosition);
    }
}
