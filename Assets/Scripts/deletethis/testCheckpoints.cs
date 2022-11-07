using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCheckpoints : MonoBehaviour
{
    //to test saving checkpoints
    //and moving the player to those checkpoints
    //il make 3 buttons which change the checkpoint stored in data
    //save/load
    //then ???

    public Transform startingPoint;
    public Transform checkpoint00;
    public Transform checkpoint01;
    public Transform checkpoint02;
    public Transform checkpoint03;

    public Transform player;

    public DataManager dataManager;

    private void Start()
    {
        dataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<DataManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public void LoadCheckPoint()
    {
        //CHECKPOINT 1 CHECK
        //this is probably not a good way to do this... too bad!
        if (startingPoint != null && dataManager.data.currentCheckpoint == "startingPoint")
        {
            player.position = startingPoint.position;
            return;
        }
        if (checkpoint00!=null&&dataManager.data.currentCheckpoint == "checkpoint00")
        {
            player.position = checkpoint00.position;
            return;
        }
        if (checkpoint01 != null && dataManager.data.currentCheckpoint == "checkpoint01")
        {
            player.position = checkpoint01.position;
            return;
        }
        //CHECKPOINT 2 CHECK
        if (checkpoint02 != null && dataManager.data.currentCheckpoint == "checkpoint02")
        {
            player.position = checkpoint02.position;
            return;
        }
        //CHECKPOINT 3 CHECK
        if (checkpoint03 != null && dataManager.data.currentCheckpoint == "checkpoint03")
        {
            player.position = checkpoint03.position;
            return;
        }
    }
    public void SetNewCheckpoint(string name)
    {
        //-called by CheckPoint.cs when the player enters the checkpoint trigger
        if(dataManager.data.currentCheckpoint != name)
        {
            dataManager.data.currentCheckpoint = name;
            dataManager.Save();
        }
    }
    public void SetStartingPosition()
    {
        dataManager.data.currentCheckpoint = startingPoint.ToString();
        dataManager.Save();
    }
}
