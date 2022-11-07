using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpawn : MonoBehaviour
{
    public GameObject spawn;

    public float SpawnDelay = 2;
    private float CurrentTime =0;

    EnemyDetection detect;

    void Start()
    {
        detect = GetComponent<EnemyDetection>();

    }

    //player in range
    //spawn enemy
    //start timer

    void Update()
    {
        if(detect.inRange == true)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (CurrentTime <= 0)
        {
            GameObject SpawnThis = Instantiate(spawn, transform.position, transform.rotation);
            CurrentTime = SpawnDelay;
        }
        else if(CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
        }
    }
}
