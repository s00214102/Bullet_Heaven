//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OrbFollow_old : MonoBehaviour
//{
//    public Transform target; //who to follow

//    public GameObject player;
//    Movement_custom_accel playerMovement;

//    Transform parentTransform;
//    Vector3 parentPosition;

//    //Vector3 currentPlayerPosition;
//    Vector3 currentTargetPosition;

//    float defaultSpeed;
//    public float currentSpeed;

//    public float deccelerationMultiplier = 0;
//    public float decelTime = 0;
//    float refVelocity = 0;
//    private Vector2 velocityRef = Vector2.zero;

//    public float minDistance = 0.5f; //how close they will get to their target
//    public float maxDistance = 2; //when over the max distance, give them a little speed boost

//    [Range(1f, 5f)]
//    public float speedBoost = 1.5f;

//    public bool normalize = false;
//    public bool forceMove = false;

//    Rigidbody2D rb => GetComponent<Rigidbody2D>();

//    void Start()
//    {
//        player = GameObject.FindGameObjectWithTag("Player");
//        playerMovement = player.GetComponent<Movement_custom_accel>();
//        defaultSpeed = playerMovement.currentSpeed;
//        currentSpeed = defaultSpeed;
//    }
//    void FixedUpdate()
//    {
//        if (target != null) //only try to move when the orb has a target
//        {
//            currentTargetPosition = target.transform.position;

//            Vector2 direction = GetDirection(); //get direction to move in
//            MoveOrb(direction);                 //move in that direction
//            CatchUp();                          //apply a speed boost if lagging behind
//        }
//    }
//    public void StopOrb()
//    {
//        target = null;
//        rb.velocity = new Vector2(0,0);
//    }
//    private Vector2 GetDirection()
//    {
//        //our position - the parents position is the direction to move in
//        Vector2 direction = target.position - transform.position;

//        if (normalize)
//        {
//            direction = direction.normalized;
//        }

//        return direction;
//    }
//    private void MoveOrb(Vector2 direction)
//    {
//        //if the distance between this object and target is greater than minimum value, move toward target
//        if (DistanceToTarget() > minDistance) 
//        {
//            if (forceMove)
//            {
//                rb.AddForce(direction * currentSpeed * Time.deltaTime, ForceMode2D.Force);
//            }
//            else
//            {
//                rb.velocity = direction * currentSpeed * Time.deltaTime;
//            }
//        }
//        //if the orb is within the minimum distance to the player, slow velocity to 0
//        else if (DistanceToTarget() < minDistance)
//        {
//            rb.velocity = Vector2.SmoothDamp(rb.velocity, Vector2.zero, ref velocityRef, decelTime);
//        }
//    }
//    private void CatchUp()
//    {
//        if (DistanceToTarget() > maxDistance) //if the distance is greater than max value, apply a speed boost
//        {
//            currentSpeed = defaultSpeed * speedBoost; //multiply starting speed by the multipier value
//        }
//        else if (DistanceToTarget() < maxDistance)
//        {
//            currentSpeed = defaultSpeed; //set speed back to starting value
//        } 
//    }

//    private float DistanceToTarget() //-change to distance to target
//    {
//        return Vector2.Distance(transform.position, currentTargetPosition);
//    }
//}
