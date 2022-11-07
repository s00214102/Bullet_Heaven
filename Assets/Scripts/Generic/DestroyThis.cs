using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    //used by animation events
    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
    public void DestroyThisObjectsParent()
    {
        Destroy(gameObject.transform.parent);
    }
}
