using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicideAnimation : MonoBehaviour
{
    //play spawning animation on start
    //use animation even to enable movement and play idle animation
    Animator anim;
    EnemyChase move;
    CircleCollider2D collider;

    EnemyData data => GetComponent<EnemyData>();

    private void Start()
    {
        anim = GetComponent<Animator>();
        move = GetComponent<EnemyChase>();
        collider = GetComponent<CircleCollider2D>();

        move.enabled = false;
        collider.enabled = false;
    }

    public void FinishedSpawning()
    {
        //play idle animation
        //enable movement/collider

        anim.Play("Idle");
        move.enabled = true;
        collider.enabled = true;
    }

    public void SelfDestruct()
    {
        data.canMove = false;
        collider.enabled = false;
        anim.Play("Self_Destruct");
    }

    public void DestroyThisObject()
    {
        Destroy(this.gameObject);
    }
}
