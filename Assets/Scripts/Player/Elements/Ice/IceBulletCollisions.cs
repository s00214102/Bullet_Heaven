using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletCollisions : MonoBehaviour
{
    float damage;
    Element element;
    PrefabElement prefabElement;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.bulletDamage;

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //-first check if hit object was an enemy
        {
            ContactPoint2D contact = col.contacts[0];

            HealthManager health;
            if (col.collider.TryGetComponent<HealthManager>(out health))
            {
                if (health.IceWeak) { health.WeaknessExploit(damage, 
                    contact.collider.ClosestPoint(transform.position), textColor, textSize); }

                else { health.TakeDamage(damage, 
                    contact.collider.ClosestPoint(transform.position), textColor); }
            }

            AilmentManager ailment;
            if (col.collider.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.FreezeBuildup();
            }

            Destroy(this.gameObject);
        }


        if (col.gameObject.CompareTag("IceDestroyable")||
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

        if (col.gameObject.CompareTag("EarthDestroyable")|| 
            col.gameObject.CompareTag("FireDestroyable")||
            col.gameObject.CompareTag("ElectricDestroyable")||
            col.gameObject.CompareTag("Untagged")) 
        {
            //-delete the bullet
            Destroy(this.gameObject);
        }
    }

    
}
