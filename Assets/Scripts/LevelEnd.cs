using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public void LoadNextLevel()
    {
        GameManager manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        manager.LoadNextScene();
    }
}
