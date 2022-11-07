using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningExplosion : MonoBehaviour
{
    float damage;
    public float explosionRadius = 2;
    Element element;
    PrefabElement prefabElement;

    Color textColor;
    float textSize;
    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        damage = element.explosionDamage;

        textColor = element.color;
        textSize = element.weaknessHitTextSize;
    }
    public void ExplosionDamage()
    {
        //make an array of colliders inside the overlap circle
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, explosionRadius, Vector2.zero);

        //for each enemy, deal damage
        for (int i = 0; i < hits.Length; i++) //go through the list and find enemies
        {
            if (hits[i].collider.gameObject.CompareTag("Enemy"))
            {
                HealthManager health;
                if(hits[i].collider.TryGetComponent<HealthManager>(out health))
                {
                    if (health.LightningWeak) { health.WeaknessExploit(damage, hits[i].point, textColor,textSize); }
                    else { health.TakeDamage(damage, hits[i].point,textColor); }
                }

                AilmentManager ailment;
                if (hits[i].collider.TryGetComponent<AilmentManager>(out ailment))
                {
                    ailment.ShockBuildup();
                }
 
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
