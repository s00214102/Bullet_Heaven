using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBomb : MonoBehaviour
{
    public Transform[] positions;
    public GameObject iceBulletPrefab;

    private void Start()
    {
        foreach (Transform t in positions)
        {
            Instantiate(iceBulletPrefab, t.position, t.rotation);
        }
        Destroy(gameObject);
    }
}
