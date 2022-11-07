using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSuiciders : MonoBehaviour
{
    public GameObject suicider;
    public Transform bulletSpawn;

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
            Instantiate(suicider, bulletSpawn.position, transform.rotation);

            CurrentTime = fireRate;
        }
    }
}
