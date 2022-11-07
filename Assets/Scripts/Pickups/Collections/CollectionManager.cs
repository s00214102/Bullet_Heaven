using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    //public Collectable[] collectables;

    public DataManager dataManager;

    private void Start()
    {
        dataManager.Load();
        //CollectableSetup();
    }
    //public void CollectableSetup()
    //{
    //    //run on start
    //    //use bool values from player data to enable/disable corresponding collectables
    //    bool[] b = dataManager.data.GetLevel1Collectables();
    //    for (int i = 0; i < b.Length; i++)
    //    {
    //        if (b[i]){ collectables[i].isCollected = true; }
    //        else { collectables[i].isCollected = false; }
    //    }
    //}
    public void CollectableSetup(string name, GameObject collectable)
    {
        //-each collectable will check if it should be enabled or disabled on start
        //basic way to do this, only thing i can think of

        //-A GROUP
        if (name == "collectableA01")
        {
            if (dataManager.data.collectableA01){collectable.SetActive(false);}
            else{collectable.SetActive(true);}
            return;
        }
        if (name == "collectableA02")
        {
            if (dataManager.data.collectableA02) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableA03")
        {
            if (dataManager.data.collectableA03) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableA04")
        {
            if (dataManager.data.collectableA04) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableA05")
        {
            if (dataManager.data.collectableA05) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableA06")
        {
            if (dataManager.data.collectableA06) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }

        //-B GROUP
        if (name == "collectableB01")
        {
            if (dataManager.data.collectableB01) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableB02")
        {
            if (dataManager.data.collectableB02) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableB03")
        {
            if (dataManager.data.collectableB03) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableB04")
        {
            if (dataManager.data.collectableB04) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableB05")
        {
            if (dataManager.data.collectableB05) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
        if (name == "collectableB06")
        {
            if (dataManager.data.collectableB06) { collectable.SetActive(false); }
            else { collectable.SetActive(true); }
            return;
        }
    }
    public void AddToCollection(string collectName)
    {
        //get the name of the collectable from the collectable that was collected
        //check through the array of collectables in the playerdata to make sure it matches a name
        //if it does, set that one to true then save

        print("trying to collect " + collectName);

        //basic way to do this, only thing i can think of
        if(collectName == "collectableA01") { dataManager.data.collectableA01 = true; Debug.Log(collectName + " matches, setting value."); dataManager.Save(); return; }
        else { Debug.Log(collectName + "!= collectableA01");}

        if (collectName == "collectableA02") { dataManager.data.collectableA02 = true; Debug.Log(collectName + " matches, setting value."); dataManager.Save(); return; }
        else { Debug.Log(collectName + "!= collectableA02");}

        if (collectName == "collectableA03") { dataManager.data.collectableA03 = true; Debug.Log(collectName + " matches, setting value."); dataManager.Save(); return; }
        else { Debug.Log(collectName + "!= collectableA03");}

        if (collectName == "collectableA04") { dataManager.data.collectableA04 = true; Debug.Log(collectName + " matches, setting value."); dataManager.Save(); return; }
        else { Debug.Log(collectName + "!= collectableA04");}

    }

}
