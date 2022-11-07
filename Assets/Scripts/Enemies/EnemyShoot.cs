using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform bulletSpawn;
    public GameObject muzzleFlash;
    public bool shootsSuiciders = false;

    float fireRate = 2;
    private float CurrentTime;

    EnemyData data => GetComponentInParent<EnemyData>();

    // Start is called before the first frame update
    void Start()
    {
        fireRate = data.bulletFireRate;

        CurrentTime = fireRate;
    }

    public void Shoot()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
        else
        {
            if (shootsSuiciders)
            {
                Instantiate(muzzleFlash, bulletSpawn.position, transform.rotation);
                GameObject suiciderClone = Instantiate(Bullet, bulletSpawn.position, transform.rotation);
                suiciderClone.GetComponent<Rigidbody2D>().AddForce(suiciderClone.transform.up * data.bulletSpeed, ForceMode2D.Force);
                CurrentTime = fireRate;
            }
            else //-shoots normal bullets
            {
                GameObject bulletClone = Instantiate(Bullet, bulletSpawn.position, transform.rotation);
                bulletClone.GetComponent<EnemyBulletCollisions>().damage = data.bulletDamage;
                bulletClone.GetComponent<Bullet>().bulletSpeed = data.bulletSpeed;
                CurrentTime = fireRate;
            }

        }
    }
}
