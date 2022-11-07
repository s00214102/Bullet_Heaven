using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningCollisions : MonoBehaviour
{
    public GameObject groundLightning; //-spawned when a fire bullet collides with something
    Bullet bullet => GetComponent<Bullet>();
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) //-first check if hit object was an enemy
        {
            ContactPoint2D contact = col.contacts[0];
            //-get the health manager component from the enemy
            //-call the take damage method and pass the damage value of this attack
            //-the damage value is stored on the fire class
            col.gameObject.GetComponent<HealthManager>().TakeDamage(3, contact.collider.ClosestPoint(transform.position));
            col.gameObject.GetComponent<AilmentManager>().ShockBuildup();

            Destroy(this.gameObject);
        }

        if (col.gameObject.CompareTag("Untagged"))
        {
            //-get the first collider hit
            //ContactPoint2D contact = col.contacts[0];

            //float angle = AngleDifference(transform.up,contact.rigidbody.transform.right);

            //if (angle < 90)
            //{
            //    //print("left");
            //    bullet.transform.up = contact.rigidbody.transform.right.normalized;
            //}
            //else if (angle >= 90)
            //{
            //    //print("right");
            //    bullet.transform.up = contact.rigidbody.transform.right.normalized * -1;
            //}

            //-delete the bullet
            Destroy(this.gameObject);
        }
       
    }


    //float AngleDifference(Vector2 angle1, Vector2 angle2)
    //{
    //    return Vector2.Angle(angle1, angle2);
    //}
    

}
