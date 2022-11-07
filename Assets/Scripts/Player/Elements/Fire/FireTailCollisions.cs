using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTailCollisions : MonoBehaviour
{
    //- fires detach ability does damage once, then again with an explosion
    //- detach damage then explosion damage

    public GameObject explosionPrefab;
    float damage;
    Element element;
    PrefabElement prefabElement;
    public MeterManager meter;

    Color textColor;
    float textSize;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.tailDamage;
        meter = prefabElement.m_Manager;

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = col.contacts[0];

            HealthManager health;
            if (col.collider.TryGetComponent<HealthManager>(out health))
            {
                if (health.FireWeak)
                {
                    health.WeaknessExploit(damage,
                    contact.collider.ClosestPoint(transform.position), textColor, textSize);
                }
                else
                {
                    health.TakeDamage(damage,
                    contact.collider.ClosestPoint(transform.position), textColor);
                }
            }

            AilmentManager ailment;
            if (col.collider.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.FireBuildup();
            }


            GameObject explosion = Instantiate(explosionPrefab, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;

            meter.SpendMeter(element.tailMeterCost);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<FireTailCollisions>().enabled = false;
        }
    }
}
