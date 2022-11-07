using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceArmCollisions : MonoBehaviour
{
    float damage;
    Element element;
    PrefabElement prefabElement;
    IceDamageOverTime damageOverTime => GetComponent<IceDamageOverTime>();
    public float radius;
    public Vector3 offset;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.armDamage;
    }

    private void FixedUpdate()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero);

        for (int i = 0; i < hits.Length; i++) //go through the list and find enemies
        {
            if (hits[i].collider.gameObject.CompareTag("Enemy"))
            {
                HealthManager health;
                if (hits[i].collider.TryGetComponent<HealthManager>(out health))
                {
                    if (health.IceWeak)
                    {
                        AilmentManager ailment;
                        if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                        {
                            damageOverTime.DoWeaknessDamageOverTime(health, ailment, damage,
                              hits[i].point);
                        }
                        else
                        {
                            damageOverTime.DoWeaknessDamageOverTime(health, damage,
                            hits[i].point);
                        }
                    }
                    else
                    {
                        AilmentManager ailment;
                        if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                        {
                            damageOverTime.DoDamageOverTime(health, ailment, damage,
                              hits[i].point);
                        }
                        else
                        {
                            damageOverTime.DoDamageOverTime(health, damage,
                            hits[i].point);
                        }
                    }
                }
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
