using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArmCollisions : MonoBehaviour
{
    public float damage;
    Element element;
    PrefabElement prefabElement;
    DamageOverTime damageOverTime => GetComponent<DamageOverTime>();
    public float fireRadius;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        Fire f = (Fire)(element);
        if (f != null) { damage = f.armDamage; }

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }

    private void FixedUpdate()
    {
        //make an array of colliders inside the overlap circle
        //Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position+offset, fireRadius);
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, fireRadius, transform.forward, 0);

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
                              hits[i].point, textColor,textSize);
                        }
                        else
                        {
                            damageOverTime.DoWeaknessDamageOverTime(health, damage,
                            hits[i].point, textColor,textSize);
                        }
                    }
                    else
                    {
                        AilmentManager ailment;
                        if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                        {
                            damageOverTime.DoDamageOverTime(health, ailment, damage,
                              hits[i].point, textColor, textSize);
                        }
                        else
                        {
                            damageOverTime.DoDamageOverTime(health, damage,
                            hits[i].point, textColor);
                        }
                    }
                }
            }

            if (hits[i].collider.gameObject.CompareTag("FireDestroyable")||
            hits[i].collider.gameObject.CompareTag("Destroyable"))
            {
                HealthManager health;
                if (hits[i].collider.TryGetComponent<HealthManager>(out health))
                {
                    damageOverTime.DoDamageOverTime(health, damage, hits[i].point);
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, fireRadius);
    }
}
