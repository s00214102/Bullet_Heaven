using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceDetached : MonoBehaviour
{
    public GameObject snowPrefab;
    [SerializeField]float snowRate = 1;
    float currentSnowTimer;
    [SerializeField] Vector3 offset;
    float lifeSpan;

    Element element;
    PrefabElement prefabElement;


    private void Start()
    {
        prefabElement = GetComponent<PrefabElement>();
        element = prefabElement.p_element;
        lifeSpan = element.detachDuration;

        currentSnowTimer = snowRate;

        Invoke("DespawnObject", lifeSpan);
    }

    void DespawnObject()
    {
        Destroy(this.gameObject);
    }
    private void Update()
    {
        SnowTimer();
        SpawnSnow();
    }

    private void SpawnSnow()
    {
        if (currentSnowTimer <= 0)
        {
            Instantiate(snowPrefab, transform.position+offset, Quaternion.identity);
            currentSnowTimer = snowRate;
        }
    }

    private void SnowTimer()
    {
        if (currentSnowTimer > 0)
        {
            currentSnowTimer -= Time.deltaTime;
        }
    }
}
