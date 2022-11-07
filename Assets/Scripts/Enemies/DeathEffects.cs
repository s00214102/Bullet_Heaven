using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffects : MonoBehaviour
{
    //public bool explode;

    public bool shoot;

    public GameObject Collectable;
    
    EnemySetup setup;
    GameObject healthDrop;
    GameObject explosionPrefab;
    public int maxHealthDrops = 8;

    private void Start()
    {
        setup = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemySetup>();
        healthDrop = setup.healthPickupPrefab;
        explosionPrefab = setup.explosionPrefab;
    }
    public void DeathEffectCheck()
    {
        Explode();

        if (shoot)
        {
            Shoot();
        }

        DropSecret();

        DropHealth();
    }

    void Explode()
    {
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log(this.gameObject.name.ToString() + " has no explosion prefab for its death effect");
        }
        
    }

    void DropSecret()
    {
        //print("Secret Test");

        //when list is made, check if collectable already collected
        if(Collectable != null)
        {
            string name = Collectable.name;
            GameObject collect = Instantiate(Collectable, transform.position, Quaternion.identity);
            collect.name = name;
        }
    }

    void Shoot()
    {
        print("Shoot Test");
    }

    void DropHealth()
    {
        int n = Random.Range(1, maxHealthDrops);

        for (int i = 0; i < n; i++)
        {
            float x = Random.Range(transform.position.x -0.5f, transform.position.x + 0.5f);
            float y = Random.Range(transform.position.y -0.5f, transform.position.y + 0.5f);

            GameObject HealthPickup = Instantiate(healthDrop, new Vector2(x, y), Quaternion.identity);
        }
    }

}
