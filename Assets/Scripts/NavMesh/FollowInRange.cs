using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowInRange : NavMeshMover
{
    GameObject TargetToFollow;
    EnemyDetection detect => GetComponent<EnemyDetection>();

    public override void Start()
    {
        base.Start();
        TargetToFollow = detect.target;
    }

    private void Update()
    {
        if (detect.inRange)
        {
            if (agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                MoveTo(TargetToFollow);
            }
        }
    }
}
