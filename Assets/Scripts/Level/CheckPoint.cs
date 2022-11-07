using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public testCheckpoints checkpointController;
    LiftCheckpointLid lift;
    public bool saving = false;
    bool savedRecently = false;
    GameObject player;
    string checkpointName;

    public GameObject playerClone;
    GameObject clone;
    Animator anim;
    Sprite currentPlayerSprite;

    //test
    private void Start()
    {
        checkpointController = GameObject.FindGameObjectWithTag("CheckpointController").GetComponent<testCheckpoints>();
        lift = GetComponentInChildren<LiftCheckpointLid>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        checkpointName = gameObject.name;
    }
    private void FixedUpdate()
    {
        if (!saving)
        {
            lift.OpenOrCloseForPlayer(GetDistance(player.transform.position));
        }
        else
        {
            lift.CloseLid();
        }
        
    }
    public void SetCurrentCheckpoint()
    {
        if (!savedRecently)
        {
            //-called by the playerCollisions class when they enter checkpoint trigger
            saving = true;

            currentPlayerSprite = player.GetComponentInChildren<SpriteRenderer>().sprite;

            clone = Instantiate(playerClone, player.transform.position, player.transform.rotation);

            clone.GetComponentInChildren<SpriteRenderer>().sprite = currentPlayerSprite;

            player.SetActive(false);

            checkpointController.SetNewCheckpoint(checkpointName);

            anim.Play("Saving");
        }

    }
    public void FinishedSaving()
    {
        print("finished saving");
        savedRecently = true;
        saving = false;
        anim.Play("Idle");
        player.SetActive(true);
        Destroy(clone);
        Invoke("ResetSave", 5f);
    }
    void ResetSave()
    {
        savedRecently = false;
    }
    float GetDistance(Vector2 target)
    {
        return Vector2.Distance(target, transform.position);
    }
}
