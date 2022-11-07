using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningDetachCollisions : MonoBehaviour
{
    Element element;
    float damage;
    PrefabElement prefabElement;
    public GameObject explosionPrefab;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.detachDamage;

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
                if (health.LightningWeak)
                {
                    health.WeaknessExploit(damage,
                    contact.collider.ClosestPoint(transform.position), textColor,textSize);
                }
                else
                {
                    health.TakeDamage(damage,
                    contact.collider.ClosestPoint(transform.position),textColor);
                }
            }

            AilmentManager ailment;
            if (col.collider.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.ShockBuildup();
            }

            GameObject explosion = Instantiate(explosionPrefab, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);
            explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;

            Destroy(gameObject);
        }
    }
}
