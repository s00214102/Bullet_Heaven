using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameFollowObject : MonoBehaviour
{
    //object teh camera will follow
    public Transform ObjectToFollow;
    Vector3 tempPosition;

    public Vector3 offset;

    void Start()
    {
        //save teh Z position of the camera
        tempPosition.z = transform.position.z;
    }

    void LateUpdate()
    {
        if (ObjectToFollow != null)
        {
            //copy the X and X position of teh player
            tempPosition.x = ObjectToFollow.position.x;
            tempPosition.y = ObjectToFollow.position.y;

            //update the camer position to be the same as the player
            transform.position = tempPosition + offset;
        }
    }
}
