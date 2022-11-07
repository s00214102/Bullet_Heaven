using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    public GameObject mover;
    public float spawnTime = 1f;
    private void Start()
    {
        InvokeRepeating("SpawnEm", spawnTime, spawnTime);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("mainmenu");
        }
    }
    void SpawnEm()
    {
        Instantiate(mover, transform.position, Quaternion.identity);
    }
}
