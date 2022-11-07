using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
//from https://www.youtube.com/watch?v=ii31ObaAaJo
public class UI_Controller : MonoBehaviour
{
    public InputField playerName;

    public DataManager dataManager;

    public GameManager gameManager;

    private void Start()
    {
        dataManager.Load();
        playerName.text = dataManager.data.name;
    }
    public void ChangeName(string text)
    {
        dataManager.data.name = text;
        dataManager.Save();
    }
}
