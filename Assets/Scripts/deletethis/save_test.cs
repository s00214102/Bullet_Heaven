using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; //-accessing things on your computer

public class save_test : MonoBehaviour
{
    //-dont save too many gameplay related stuff in here
    private void Start()
    {
        CreateProfile("marc");
    }
    public void CreateProfile(string username)
    {
        //-location to save the profile

        //for development (wont work for a build)
        string devPath = Application.dataPath; //within the project folder

        //build save location
        string deployedPath = Application.persistentDataPath; //saved to drive appdata/locallow

        string savePath = devPath + "/Saves/";

        if (!Directory.Exists(savePath))
            Directory.CreateDirectory(savePath);

        //give path, name of file, text (note, this wont generate a folder)
        File.WriteAllText(devPath + "/testfile.txt", "Test!"); //create a text file in devpath with the word "test!"

        string loadText = File.ReadAllText(devPath + "/Saves/testfile.txt");
        Debug.Log(loadText);

        //
        string filePath = savePath + "/" + username + ".json";
        if(!File.Exists(savePath + "/" + username + ".json")) //checks for a file with username.json
        {
            //create profile
            userprofile_test profile = new userprofile_test(username, 50, 25, 2);

            //convert this to JSON
            string json = JsonUtility.ToJson(profile);

            //save json
            File.WriteAllText(filePath, json);
              
        }
        else
        {
            //profile exists, dispaly message
        }
    }
}
