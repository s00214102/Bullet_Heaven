using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]public class PlayerData
{
    public string name = "";
    public string currentCheckpoint ="";
    public string currentLevel ="";

    [Header("Collectables")]

    public bool collectableA01 = false;
    public bool collectableA02 = false;
    public bool collectableA03 = false;
    public bool collectableA04 = false;
    public bool collectableA05 = false;
    public bool collectableA06 = false;

    public bool collectableB01 = false;
    public bool collectableB02 = false;
    public bool collectableB03 = false;
    public bool collectableB04 = false;
    public bool collectableB05 = false;
    public bool collectableB06 = false;
    //string[] c_Names;


    public bool[] GetLevel1Collectables()
    {
        bool[] collectables = { collectableA01, collectableA02, collectableA03, collectableA04 };
        return collectables;
    }
    //public string[] GetLevel1CollectableNames()
    //{
    //    bool[] collectables = { collectableA01, collectableA02, collectableA03, collectableA04 };
    //    //string[] c_Names;
    //    for (int i = 0; i < collectables.Length; i++)
    //    {
    //        c_Names[i].Equals(collectables[i].ToString());
    //    }
    //    return c_Names;
    //}
    //public void SetCollectable(string name)
    //{
    //    //pass in a name
    //    //go through a list of all collectable names
    //    //for the name it matches, make that bool true

    //    //string[] s = GetLevel1CollectableNames();
    //    //foreach (string n in s)
    //    //{
    //    //    if (name == n) {  }
    //    //}

    //    bool[] b = GetLevel1Collectables();
    //    foreach (bool collectable in b)
    //    {
    //        Debug.Log("checking: " + collectable.GetType().);
    //        if (name == collectable.ToString())
    //        {
    //            collectable.Equals(true);
    //            Debug.Log(collectable.ToString() + " was set to " + collectable);
    //            return;
    //        }
    //    }
    //    Debug.Log(name+" did not match any collectable entry in PlayerData.");
    //}
}
