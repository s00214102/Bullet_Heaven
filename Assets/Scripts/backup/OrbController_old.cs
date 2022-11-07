using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController_old : MonoBehaviour
{
    //PlayerData playerData => GetComponent<PlayerData>();
    PlayerData playerData => GetComponentInParent<PlayerData>();

    public ElementManager element;

    //public GameObject orb;

    public List<GameObject> orbs = new List<GameObject>();
    void Start()
    {
        SpawnStartingOrbs();
    }
    public void SpawnStartingOrbs()
    {
        //for (int i = 1; i <= playerData.startingOrbs; i++)
        //{
        //    //Instantiate(orb, transform.position, Quaternion.identity);
        //    SpawnOrb();
        //}

        SetOrbTrailTargets();
    }
    public void SpawnArmOrbs()
    {
        //for (int i = 1; i <= playerData.startingOrbs; i++)
        //{
        //    //Instantiate(orb, transform.position, Quaternion.identity);
        //    SpawnArmOrb();
        //}
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
            Invoke("SpawnStartingOrbs", 2f);
        }
    }
    void SpawnOrb()
    {
         orbs.Add(Instantiate(element.currentElement.activeOrbPrefab, transform.position, Quaternion.identity));
    }
    void SpawnArmOrb()
    {
        orbs.Add(Instantiate(element.currentElement.armPrefab, transform.position, Quaternion.identity));
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
    bool OrbCheck()
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
}
