using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbData : MonoBehaviour
{
    //-this is where all the orbs variables are stored

    //- orb follow values
    public GameObject player;

    public float minDistance = 1.26f;
    public float maxDistance = 2;
    public float speedBoost = 4;

    public bool normalize = false;
    public bool forceMove = false;

    //-rigidbody values
    public Rigidbody2D rb;
    public float mass = 0.25f;
    public float linearDrag = 0;
    public float angularDrag = 0;
    public float gravityScale = 0;

    //-circle collider values
    public CircleCollider2D circleCollider;
    public bool isTrigger = true;
    public float radius = 0.1f;

    private float m_test;

    public float Test
    {
        get{ return m_test; }
        set { m_test = value; }
    }


}
