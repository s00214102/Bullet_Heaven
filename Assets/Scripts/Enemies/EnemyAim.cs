using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAim : MonoBehaviour
{

    public EnemyShoot[] shoot;

    EnemyDetection detect;
    LineOfSight lineOfSight;

    float time = 0;
    float speed = 5f;

    EnemyData data => GetComponentInParent<EnemyData>();

    // Start is called before the first frame update
    void Start()
    {
        detect = GetComponentInParent<EnemyDetection>();
        lineOfSight = GetComponentInParent<LineOfSight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lineOfSight == null)
        {
            lineOfSight = GetComponentInParent<LineOfSight>();
        }

        if (lineOfSight.hasLineOfSight)
        {
            //if (time < 1) { time += 0.01f; }
            //transform.up = transform.position - detect.target.transform.position ;
            //transform.up = Vector2.Lerp(transform.up, transform.up - detect.target.transform.position, time);

            FollowWithAim();

            Attack();
        }
    }
    void FollowWithAim()
    {
        Vector2 direction = detect.target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
    private void Attack()
    {
        if (data.canAttack)
        {
            for (int i = 0; i < shoot.Length; i++)
            {
                shoot[i].Shoot();
            }

        }
    }
}
