using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTailCollisions : MonoBehaviour
{
    Element element;
    float damage;
    PrefabElement prefabElement;
    public GameObject explosionPrefab;
    public MeterManager meter;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.tailDamage;
        meter = prefabElement.m_Manager;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = col.contacts[0];

            HealthManager health;
            if (col.collider.TryGetComponent<HealthManager>(out health))
            {
                if (health.IceWeak)
                {
                    health.WeaknessExploit(damage,
                    contact.collider.ClosestPoint(transform.position));
                }
                else
                {
                    health.TakeDamage(damage,
                    contact.collider.ClosestPoint(transform.position));
                }
            }

            AilmentManager ailment;
            if (col.collider.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.FreezeBuildup();
            }


            GameObject explosion = Instantiate(explosionPrefab,
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;

            meter.SpendMeter(element.tailMeterCost);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<IceTailCollisions>().enabled = false;
        }
    }
}
