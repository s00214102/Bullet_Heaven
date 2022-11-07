using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArmCollisions : MonoBehaviour
{
    float damage;
    Element element;
    PrefabElement prefabElement;
    LightningDamageOverTime damageOverTime => GetComponent<LightningDamageOverTime>();
    public float radius;
    public Vector3 offset;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.armDamage;

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
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
                    if (health.LightningWeak)
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
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
