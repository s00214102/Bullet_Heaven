using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFollowerCollisions : MonoBehaviour
{

    public float fireRadius;
    public float damage = 4;
    public Vector3 offset;
    DamageOverTime damageOverTime => GetComponent<DamageOverTime>();

    Color textColor = Color.red;
    float textSize = 5;

    private void FixedUpdate()
    {
        FireDamage();
    }
    public void FireDamage()
    {
        //make an array of colliders inside the overlap circle
        //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, fireRadius);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, fireRadius, transform.up);

        //for each enemy, deal damage
        for (int i = 0; i < hits.Length; i++) //go through the list and find enemies
        {
            if (hits[i].collider.gameObject.CompareTag("Enemy"))
            {
                HealthManager health;
                if (hits[i].collider.TryGetComponent<HealthManager>(out health))
                {
                    if (health.FireWeak)
                    {
                        AilmentManager ailment;
                        if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                        {
                            damageOverTime.DoWeaknessDamageOverTime(health, ailment, damage,
                              hits[i].point, textColor, textSize);
                        }
                        else
                        {
                            damageOverTime.DoWeaknessDamageOverTime(health, damage,
                            hits[i].point, textColor, textSize);
                        }
                    }
                    else
                    {
                        AilmentManager ailment;
                        if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                        {
                            damageOverTime.DoDamageOverTime(health, ailment, damage,
                              hits[i].point, textColor);
                        }
                        else
                        {
                            damageOverTime.DoDamageOverTime(health, damage,
                            hits[i].point, textColor);
                        }
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fireRadius);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (follow.ObjectToFollow == null)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
