using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletLifeSpan : MonoBehaviour
{
    float lifeSpan = 0;
    Element element;
    PrefabElement prefabElement;

    void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        if (element != null)
        {
            lifeSpan = element.bulletLifespan;
        }

        Invoke("DespawnObject", lifeSpan);
    }

    void DespawnObject()
    {
        FireBulletCollisions fire;
        if (TryGetComponent<FireBulletCollisions>(out fire))
        {
            fire.SpawnExplosion(transform);
        }
        Destroy(this.gameObject);
    }
}
