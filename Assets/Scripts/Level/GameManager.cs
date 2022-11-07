using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public DataManager dataManager;
    public testCheckpoints checkpoints;
    Scene currentScene;
    void Start()
    {
        //DontDestroyOnLoad(gameObject);

        if (GameObject.FindGameObjectWithTag("DataManager").TryGetComponent<DataManager>(out dataManager))
            dataManager.Load();

        try
        {
            GameObject checkPointGO = GameObject.FindGameObjectWithTag("CheckpointController");

            if (checkPointGO != null)
                if (checkPointGO.TryGetComponent<testCheckpoints>(out checkpoints))
                    checkpoints.LoadCheckPoint(); 
        }
        catch
        {
            Debug.Log("No GameObject with tag 'CheckpointController' found.");
        }
        

        currentScene = SceneManager.GetActiveScene();

        if (dataManager != null)
            NewLevelCheck();

        if (dataManager != null)
            LoadingScreenCheck();
    }

    private void NewLevelCheck()
    {
        //-are we in a saveable level?
        if (dataManager.level.SaveableLevel(currentScene.name))
        {
            print("we are in a saveable level");

            //-have we already saved this level?
            if (dataManager.data.currentLevel == currentScene.name) return;
            dataManager.data.currentLevel = currentScene.name;
            dataManager.Save();

        }
        else { print("NOT a saveable level"); }
    }

    private void LoadingScreenCheck()
    {
        //-check if this is the loading screen
        if (currentScene.name == "LoadingScreen")
        {
            //-load the saved level - if its not null
            if (!string.IsNullOrEmpty(dataManager.data.currentLevel))
            {
                print("loading saved level");
                LoadScene(dataManager.data.currentLevel);
            }
            else dataManager.data.currentCheckpoint = "startingPoint"; dataManager.Save();  LoadScene("MarcsLevel"); //GIVE THE INDEX OF THE FIRST LEVEL HERE
        }
    }

    void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void LoadNextScene()
    {
        currentScene = SceneManager.GetActiveScene();
        int index = currentScene.buildIndex;
        index += 1;

        dataManager.data.currentCheckpoint = "startingPoint";
        dataManager.Save();

        LoadScene(index);
    }
    public void LoadPreviousScene()
    {
        currentScene = SceneManager.GetActiveScene();
        int index = currentScene.buildIndex;
        index -= 1;

        LoadScene(index);
    }
    public void ReloadScene()
    {
        currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    public void LoadMainMenu()
    {
        LoadScene("mainmenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
