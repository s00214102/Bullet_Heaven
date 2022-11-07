using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthBulletCollisions : MonoBehaviour
{
    float damage;
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    Element element;
    PrefabElement prefabElement;
    Color textColor;
    float textSize;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }
    private void FixedUpdate()
    {
        damage = rb.velocity.magnitude;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) 
        {
            ContactPoint2D contact = col.contacts[0];

            //col.gameObject.GetComponent<HealthManager>().TakeDamage(currentSpeed, contact.collider.ClosestPoint(transform.position));
            //col.gameObject.GetComponent<AilmentManager>().StunBuildup(currentSpeed);

            HealthManager health;
            if (col.gameObject.TryGetComponent<HealthManager>(out health))
            {
                if (health.EarthWeak) { health.WeaknessExploit(damage, contact.collider.ClosestPoint(transform.position), textColor, textSize); }
                else { health.TakeDamage(damage, contact.collider.ClosestPoint(transform.position), textColor); }
            }

            AilmentManager ailment;
            if (col.gameObject.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.StunBuildup(damage);
            }

            EnemyShield shield; //-if the enemy has a shield, deal 1 damage to it.
            if (col.gameObject.TryGetComponent<EnemyShield>(out shield))
            {
                shield.ShieldDamage();
            }

            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Untagged")||
            col.gameObject.CompareTag("IceDestroyable")||
            col.gameObject.CompareTag("FireDestroyable")||
            col.gameObject.CompareTag("ElectricDestroyable"))
        {
            Destroy(this.gameObject);
        }


        if (col.gameObject.CompareTag("EarthDestroyable")||
            col.gameObject.CompareTag("Destroyable"))
        {
            ContactPoint2D contact = col.contacts[0];
            //col.gameObject.GetComponent<Destroyable>().Damage();
            HealthManager health;
            if (col.gameObject.TryGetComponent<HealthManager>(out health))
            {
                health.TakeDamage(damage, contact.collider.ClosestPoint(transform.position), textColor);
            }
            Destroy(this.gameObject);
        }

    }

    
}
