using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCollisions : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            AilmentManager ailment;
            if (col.TryGetComponent<AilmentManager>(out ailment))
            {
                ailment.FreezeBuildup();
            }
        }
        if (col.CompareTag("Untagged"))
        {
            Destroy(gameObject);
        }
    }
}
