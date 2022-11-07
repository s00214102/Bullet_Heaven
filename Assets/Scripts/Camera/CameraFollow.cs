using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CameraFollow : MonoBehaviour
{
    //object the camera will follow
    public Transform ObjectToFollow;
    Vector3 tempPosition;
    public Vector3 offset;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //save teh Z position of the camera
        tempPosition.z = transform.position.z;
    }

    void LateUpdate()
    {
        //copy the X and X position of teh player
        tempPosition.x = ObjectToFollow.position.x;
        tempPosition.y = ObjectToFollow.position.y;

        //update the camer position to be the same as the player
        //transform.position = tempPosition + offset;
        rb.MovePosition(tempPosition + offset);
    }
}
