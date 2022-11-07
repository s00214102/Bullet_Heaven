using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerHealthManager health => GetComponentInParent<PlayerHealthManager>();
    SpriteRenderer sprite => GetComponentInChildren<SpriteRenderer>();

    public GameObject playerClone;
    Sprite currentPlayerSprite;
    GameObject clone;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Collectable"))
        {
            col.GetComponent<Collectable>().Collect();
        }
        if (col.gameObject.CompareTag("Checkpoint"))
        {
            col.GetComponent<CheckPoint>().SetCurrentCheckpoint();
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            currentPlayerSprite = GetComponentInChildren<SpriteRenderer>().sprite;

            clone = Instantiate(playerClone, transform.position, transform.rotation);

            clone.GetComponentInChildren<SpriteRenderer>().sprite = currentPlayerSprite;

            clone.GetComponent<LevelEndPlayerMove>().destination = col.gameObject.transform;
            clone.GetComponent<LevelEndPlayerMove>().canMove = true;

            gameObject.SetActive(false);

            //GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            //manager.LoadNextScene();
        }
        if (col.gameObject.CompareTag("HiddenArea"))
        {
            col.GetComponent<HiddenArea>().UnveiledArea();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Health"))
        {
            float health = col.gameObject.GetComponent<HealthPickup>().health;

            this.health.GainHealth(health);

            Destroy(col.gameObject);
        }
    }
}
