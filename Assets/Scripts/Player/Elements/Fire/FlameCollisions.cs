using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollisions : MonoBehaviour
{
    Rigidbody2D rb => GetComponent<Rigidbody2D>();
    DamageOverTime damageOverTime => GetComponent<DamageOverTime>();

    float damage;
    Element element;
    PrefabElement prefabElement;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        Fire f = (Fire)(element);
        if (f != null) { damage = f.flameDamage; }

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Untagged"))
        {
            rb.gravityScale = 0;
            //rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Untagged"))
        {
            rb.gravityScale = 1;
            //rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //-first check if hit object was an enemy
        {
            //HealthManager enemyHealth = col.GetComponent<HealthManager>();
            //damageOverTime.DoDamageOverTime(enemyHealth, damage, col.ClosestPoint(transform.position));

            HealthManager health;
            if (col.TryGetComponent<HealthManager>(out health))
            {
                if (health.FireWeak)
                {
                    damageOverTime.DoWeaknessDamageOverTime(health, damage,
                    col.ClosestPoint(transform.position), textColor, textSize);
                }
                else
                {
                    damageOverTime.DoDamageOverTime(health, damage,
                    col.ClosestPoint(transform.position), textColor);
                }
            }
        }

        if (col.gameObject.CompareTag("FireDestroyable") ||
           col.gameObject.CompareTag("Destroyable"))
        {
            HealthManager health;
            if (col.TryGetComponent<HealthManager>(out health))
            {
                damageOverTime.DoDamageOverTime(health, damage, col.ClosestPoint(transform.position), textColor);
            }
        }
    }
}
