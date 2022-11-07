using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject player;
    bool isPaused = false;

    private void Start()
    {
        UnPause();
    }
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseScreen.SetActive(true);
        player.SetActive(false);
    }

    public void UnPause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        player.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }
}
