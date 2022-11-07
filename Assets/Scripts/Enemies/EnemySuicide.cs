using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicide : MonoBehaviour
{
    public int damage = 20;
    GameObject m_player;
    EnemySuicideAnimation anim => GetComponent<EnemySuicideAnimation>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StorePlayer(collision.gameObject); //store player to damage later with animation event

            anim.SelfDestruct(); //play self destruct animation etc.
        }
    }

    void StorePlayer(GameObject player)
    {
        m_player = player;
    }
    public void DamagePlayer() //-call from animation event
    {
        //m_player.GetComponent<MeterManager>().LoseMeter(damage);
        m_player.GetComponent<PlayerHealthManager>().LoseHealth(damage);
    }
}
