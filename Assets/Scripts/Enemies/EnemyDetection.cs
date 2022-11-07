using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [HideInInspector]public GameObject target;

    public float range;

    public bool inRange = false;
    public bool gizmoOn = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetDistance() < range)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }

    float GetDistance()
    {
        return Vector2.Distance(target.transform.position, transform.position);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
