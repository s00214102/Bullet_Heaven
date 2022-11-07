using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public float lifeSpan = 0;
    void Start()
    {
        Invoke("DespawnObject", lifeSpan);
    }

    void DespawnObject()
    {
        Destroy(this.gameObject);
    }
}
