using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDetachCollisions : MonoBehaviour
{
    //-fire detach does and explosion for some damage and spawns a flame for more damage

    public GameObject groundFlame; //-spawn a flame
    public GameObject explosionPrefab; //-spawn an explosion

    Element element;
    PrefabElement prefabElement;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //-first check if hit object was an enemy
        {
            ContactPoint2D contact = col.contacts[0];
            
            GameObject explosion = Instantiate(explosionPrefab, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);

            explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;


            GameObject flame = Instantiate(groundFlame, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);

            flame.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;

            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Untagged"))
        {
            ContactPoint2D contact = col.contacts[0];

            GameObject explosion = Instantiate(explosionPrefab, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);

            explosion.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;


            GameObject flame = Instantiate(groundFlame, 
                contact.collider.ClosestPoint(transform.position), Quaternion.identity);

            flame.GetComponent<PrefabElement>().p_element = GetComponent<PrefabElement>().p_element;

            //-delete the bullet
            Destroy(this.gameObject);
        }
       
    }

    
}
