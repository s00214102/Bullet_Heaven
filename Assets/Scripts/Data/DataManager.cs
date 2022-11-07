using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
//from https://www.youtube.com/watch?v=ii31ObaAaJo
public class DataManager : MonoBehaviour
{
    public PlayerData data;
    public LevelData level;

    private string file = "player.txt";

    public void Save()
    {
        //convert our data class to json and save it to our file
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }
    public void Load()
    {
        data = new PlayerData();
        level = new LevelData();
        string json = ReadFromFile(file);

        //overwrite the json using the data
        JsonUtility.FromJsonOverwrite(json, data);
    }
    void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);

        //?????????? magic time
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }
    string ReadFromFile(string fileName)
    {
        //check if the file exists before trying to read it
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            //???????????????? more magic
            using (StreamReader reader = new StreamReader(path))
            {
                //return a new json, using ReadToEnd method
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else Debug.LogWarning("File not found!");
        return "";
    }
    string GetFilePath(string fileName)
    {
        //return the file path and our file name as a string
        return Application.persistentDataPath + "/" + fileName;
    }
    public void DeleteSaveFile()
    {
        File.Delete(Application.persistentDataPath + "/" + file);
    }
}
