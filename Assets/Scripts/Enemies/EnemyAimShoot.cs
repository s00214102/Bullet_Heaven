using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletSpawn;

    float fireRate = 2;
    private float CurrentTime;

    EnemyDetection detect;
    LineOfSight lineOfSight;

    EnemyData data;

    // Start is called before the first frame update
    void Start()
    {
        data = GetComponentInParent<EnemyData>();

        fireRate = data.bulletFireRate;
        detect = GetComponentInParent<EnemyDetection>();
        lineOfSight = GetComponentInParent<LineOfSight>();
        CurrentTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (lineOfSight.hasLineOfSight)
        {
            transform.up = detect.target.transform.position - transform.position;
            if (data.canAttack)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            GameObject bulletClone = Instantiate(Bullet, bulletSpawn.position, transform.rotation);
            bulletClone.GetComponent<EnemyBulletCollisions>().damage = data.bulletDamage;
            bulletClone.GetComponent<Bullet>().bulletSpeed = data.bulletSpeed;
            CurrentTime = fireRate;
        }
    }
}
