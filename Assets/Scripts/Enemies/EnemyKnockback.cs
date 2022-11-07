using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        TestKnockBack();
    }
    public void DoKnockBack(Vector3 position, float force)
    {
        //pass is the position the knockback came from and the force of the knockback
        //calculate the new direction to move in based on passed position and current position
        //use addForce impulse to move object in that direction

        //print("trying to apply knockback with "+force+" force");

        Vector3 newDirection = this.transform.position - position;

        rb.AddForce(newDirection * force, ForceMode2D.Force);
    }

    void TestKnockBack()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            rb.AddForce(transform.up * 400, ForceMode2D.Force);
        }
    }
}
