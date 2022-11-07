using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    //public bool isCollected = false;
    CollectionManager collectionManager;

    private void Start()
    {
        collectionManager = GameObject.FindGameObjectWithTag("CollectionManager").GetComponent<CollectionManager>();

        //if (isCollected) { gameObject.SetActive(false); }
        collectionManager.CollectableSetup(gameObject.name, gameObject);
    }
    public void Collect()
    {
        //-call this method when player collides with this 
        collectionManager.AddToCollection(gameObject.name);
        gameObject.SetActive(false);
    }
}
