using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHoming : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float homingSpeed = 100;
    OrbFollow follow;
    bool searchForEnemy = true;
    private void Awake()
    {
        follow = GetComponent<OrbFollow>();
    }
    void FixedUpdate()
    {
        if (follow.target == null) { searchForEnemy = true; }
        if (searchForEnemy) { CircleCast(); }
    }

    private void CircleCast()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, radius);

        for (int i = 0; i < hits.Length; i++) //go through the list and find enemies
        {
            if (hits[i].gameObject.CompareTag("Enemy"))
            {
                follow.target = hits[i].gameObject.transform;
                follow.defaultSpeed = homingSpeed;
                searchForEnemy = false;
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
