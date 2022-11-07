using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletCollisions : MonoBehaviour
{
    public GameObject explosionPrefab; //-spawned when a fire bullet collides with something

    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("FireDestroyable")|| 
            col.gameObject.CompareTag("Destroyable")||
            col.gameObject.CompareTag("Untagged")||
            col.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = col.contacts[0];
            SpawnExplosion(contact);
        }

        if (col.gameObject.CompareTag("EarthDestroyable") ||
            col.gameObject.CompareTag("IceDestroyable") ||
            col.gameObject.CompareTag("ElectricDestroyable"))
        {
            ContactPoint2D contact = col.contacts[0];
            SpawnExplosion(contact);
        }
    }

    private void SpawnExplosion(ContactPoint2D contact)
    {
        GameObject explosion = Instantiate(explosionPrefab, contact.collider.ClosestPoint(transform.position), Quaternion.identity);
        explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;
        Destroy(this.gameObject);
    }
    public void SpawnExplosion(Transform point)
    {
        GameObject explosion = Instantiate(explosionPrefab, point.position, Quaternion.identity);
        explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;
        Destroy(this.gameObject);
    }
}
