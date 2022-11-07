using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    //-what are the levels to be saved
    string[] levels = { "level01", "level02", "level03", "MarcsLevel", "JacksLevel" };

    //give an index get a string level back
    public string GetLevelName(int index)
    {
          return levels[index];
    }
    public bool SaveableLevel(string level)
    {
        //pass it a string and it will tell you if that is level in the array
        bool saveable = false;
        foreach (string s in levels)
        {
            if(level == s)  saveable = true; 
        }
        return saveable;
    }
}
