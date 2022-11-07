using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{

    public Transform target;

    void Update()
    {
        transform.up = target.position - transform.position;
    }
}
