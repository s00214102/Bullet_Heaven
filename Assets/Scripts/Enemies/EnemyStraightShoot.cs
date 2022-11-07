using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStraightShoot : MonoBehaviour
{
    public GameObject Parent;
    public Transform bulletSpawn;
    public GameObject Bullet;

    [HideInInspector] public float fireRate = 2;
    private float CurrentTime;

    EnemyData data => GetComponentInParent<EnemyData>();

    // Start is called before the first frame update
    void Start()
    {
        fireRate = data.bulletFireRate;

        CurrentTime = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (data.canAttack)
        {
            Shoot();
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
