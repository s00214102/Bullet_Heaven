using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBump : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<MeterManager>().LoseMeter(damage);
            collision.gameObject.GetComponent<PlayerHealthManager>().LoseHealth(damage);
        }
    }
}
