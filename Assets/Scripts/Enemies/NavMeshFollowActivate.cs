using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshFollowActivate : MonoBehaviour
{
    EnemyDetection detect;
    FollowInRange follow;

    EnemyData data => GetComponent<EnemyData>();

    void Start()
    {
       //var agent = GetComponent<NavMeshAgent>();
       //agent.updateRotation = false;
       //agent.updateupAxis = false;

        detect = GetComponent<EnemyDetection>();
        follow = GetComponent<FollowInRange>();
    }

    void Update()
    {
        if (detect.inRange)
        {
            if (data.canMove)
            {
                follow.enabled = true;
            }
        }
        else
        {
            follow.enabled = false;
        }
    }
}
