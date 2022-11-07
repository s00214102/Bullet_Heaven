using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthCollisions : MonoBehaviour
{
    float currentSpeed;
    float knockBackForce;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();

    private void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;

        knockBackForce = currentSpeed * 10;

        if (knockBackForce <= 0) knockBackForce = 0.1f;
        //print(currentSpeed);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //-first check if hit object was an enemy
        {
            //-get the health manager component from the enemy
            //-call the take damage method and pass the damage value of this attack
            //-the damage value is stored on the fire class
            col.gameObject.GetComponent<HealthManager>().TakeDamage(0);

            EnemyKnockback knockback;
            if (col.gameObject.TryGetComponent<EnemyKnockback>(out knockback))
            {
                knockback.DoKnockBack(transform.position, knockBackForce);
            }

            EnemyShield shield; //-if the enemy has a shield, deal 1 damage to it.
            if (col.gameObject.TryGetComponent<EnemyShield>(out shield))
            {
                shield.ShieldDamage();
            }
        }

    }

    
}
