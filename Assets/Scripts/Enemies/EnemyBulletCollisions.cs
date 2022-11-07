using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollisions : MonoBehaviour
{
    [HideInInspector] public float damage;
    public GameObject explosion;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.contacts[0];

            collision.gameObject.GetComponent<PlayerHealthManager>().LoseHealth(damage);
            Instantiate(explosion, contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Destroyable"))
        {
            ContactPoint2D contact = collision.contacts[0];
            HealthManager health;
            if (collision.gameObject.TryGetComponent<HealthManager>(out health))
            {
                health.TakeDamage(damage, contact.collider.ClosestPoint(transform.position));
            }
            Instantiate(explosion, contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (!collision.gameObject.CompareTag("Player")&&
            !collision.gameObject.CompareTag("Destroyable"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Instantiate(explosion, contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
