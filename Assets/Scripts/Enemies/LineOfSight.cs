using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    //-when the player is in range of this enemy
    //-draw a ray towards the player
    //-if it hits, we have line of sight
    //-only aim/shoot when we have LOS

    Transform player;
    Vector3 playerDirection;
    public bool hasLineOfSight = false;

    public LayerMask layer;
    public float maxDistance = 10;
    Vector3 start;
    Vector3 end;

    EnemyDetection detection;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        detection = GetComponent<EnemyDetection>();
    }
    private void Update()
    {
        if (detection.inRange)
        {
            start = transform.position;

            if (player == null){ player = GameObject.FindGameObjectWithTag("Player").transform; }

            playerDirection = player.position - start;

            PerformRayCast();
        }
        else
        {
            hasLineOfSight = false;
        }
    }
    void PerformRayCast()
    {
        //gets the end point of the lightning strike
        //deals damage to any enemy it hits

        RaycastHit2D raycastHit = Physics2D.Raycast(start, playerDirection, maxDistance, layer);

        if (raycastHit.collider != null) // has to hit a collider to stop
        {
            end = raycastHit.point;

            GameObject hitobject = raycastHit.collider.gameObject;

            if (hitobject.CompareTag("Player"))
            {
                hasLineOfSight = true;
            }
            else
            {
                hasLineOfSight = false;
            }

        }
        else // stop at a maximum set distance
        {
            end = start + transform.up * maxDistance;
            hasLineOfSight = false;
        }

    }
}
