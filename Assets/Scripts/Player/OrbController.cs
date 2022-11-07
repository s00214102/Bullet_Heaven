using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    //PlayerData playerData => GetComponent<PlayerData>();
    PlayerData playerData => GetComponentInParent<PlayerData>();

    public ElementManager element;
    public MeterManager meter;
    //public GameObject orb;

    public List<GameObject> orbs = new List<GameObject>();
    //void Start()
    //{
    //    SpawnInactiveOrbs();
    //}
    private void OnDisable()
    {
        DespawnAllOrbs();
    }
    private void OnEnable()
    {
        SpawnInactiveOrbs();
    }
    public void SpawnInactiveOrbs()
    {
        if (OrbCheck()) return;

        for (int i = 1; i <= element.currentElement.startingOrbs; i++)
        {
            //Instantiate(orb, transform.position, Quaternion.identity);
            SpawnOrb(element.currentElement.inactiveOrbPrefab);
        }

        SetOrbTrailTargets();
    }
    public void SpawnArmOrbs()
    {
        for (int i = 1; i <= element.currentElement.startingOrbs; i++)
        {
            //Instantiate(orb, transform.position, Quaternion.identity);
            SpawnOrb(element.currentElement.armPrefab);
        }
    }
    public void SwapToNewOrb(GameObject prefab) //-swap the inactive orbs for active ones
    {
        if (OrbCheck())
        {
            List<Vector2> positions = new List<Vector2>();

            for (int i = 0; i < orbs.Count; i++) //-loop through every item in the list
            {
                positions.Add(orbs[i].transform.position);
                Destroy(orbs[i].gameObject);
            }
            orbs.Clear();
            foreach(Vector2 p in positions)
            {
                SpawnOrb(prefab, p);
            }
        }
    }
    public void StopOrbFollow()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                //orbs[i].GetComponent<OrbFollow>().StopOrb();

                //add the orb detach class to each orb in its list
                orbs[i].AddComponent<OrbDetached>();
            }

            //-after adding orbDetached to each orb, clear the list of orbs
            orbs.Clear();

            //-after a delay, spawn more orbs
            Invoke("SpawnInactiveOrbs", 2f);
        }
    }
    void SpawnOrb(GameObject orb)
    {
         orbs.Add(Instantiate(orb, transform.position, Quaternion.identity));
    }
    void SpawnOrb(GameObject orb, Vector2 position)
    {
        orbs.Add(Instantiate(orb, position, Quaternion.identity));
    }
    public void DespawnAllOrbs()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                Destroy(orbs[i].gameObject);
            }
            orbs.Clear();
        }
    }
    public void SetOrbTrailTargets()
    {
        if (OrbCheck())
        {
            //set the target of each list item to be the next list item
            //for the final list item make its target the player
            for (int i = 0; i < orbs.Count - 1; i++)
            {
                orbs[i].GetComponent<OrbFollow>().target = orbs[i + 1].GetComponent<Transform>();
            }

            //set the last orbs target to player position
            orbs[orbs.Count - 1].GetComponent<OrbFollow>().target = this.gameObject.transform;
        }
    }
    void SetOrbShootTargets()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                orbs[i].GetComponent<OrbFollow>().target = this.gameObject.transform;
            }
        }
    }
    public void SetOrbsToActive()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                orbs[i].GetComponent<Collider2D>().isTrigger = false;
            }
        }
    }
    public void SetOrbsElement() //-give the orb prefabs the current element class
    {   
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                orbs[i].GetComponent<PrefabElement>().p_element = element.currentElement;
            }
        }
    }
    public void SetOrbsMeterManager()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                orbs[i].GetComponent<PrefabElement>().m_Manager = meter;
            }
        }
    }
    public void SetOrbsToInActive()
    {
        if (OrbCheck())
        {
            for (int i = 0; i < orbs.Count; i++)
            {
                orbs[i].GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
    public bool OrbCheck()
    {
        if (orbs.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool TailNullCheck()
    {
        //-check if a orb on the tail was destroyed

        for (int i = 0; i < orbs.Count; i++)
        {
            if (orbs[i].Equals(null))
            {
                orbs.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}
