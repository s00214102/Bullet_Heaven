using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour
{
    //array of tutorial gameobjects
    //when spacebar is pressed,
    //-current gameobject
    //-enable next gameobject
    //-use int counter to keep track
    //-when at the end go back to main menu

    public GameObject[] tutorials;
    int counter = 0;

    private void Start()
    {
        tutorials[counter].SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorials[counter].SetActive(false);
            counter++;
            if(counter == 7) { ExitTutorial(); return; }
            tutorials[counter].SetActive(true);
        }
    }

    void ExitTutorial()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
