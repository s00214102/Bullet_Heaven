using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthTailCollisions : MonoBehaviour
{
    float damage;
    public float damageMulti = 2;
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
        //-set the damage equal to our velocity
        damage = rb.velocity.magnitude*damageMulti;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //-get the first collider hit
            ContactPoint2D contact = col.contacts[0];

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
        }

        if (col.gameObject.CompareTag("EarthDestroyable") ||
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
