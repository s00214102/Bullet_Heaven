using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShardCollisions : MonoBehaviour
{
    float damage;
    Element element;
    PrefabElement prefabElement;
    public Collider2D col;

    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();

        element = prefabElement.p_element;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            //-get the first collider hit
            ContactPoint2D contact = col.contacts[0];
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Untagged"))
        {

        }
    }

}
