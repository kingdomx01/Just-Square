// Add System.IO to work with files!
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDataManager
{
    // Create a field for the save file.
    public static string directory = "/SaveData/";
    public static string fileName = "save.txt";
    public static void SaveMethod(GameData gameData)
    {
        string dir = Application.persistentDataPath + directory;
        if (!Directory.Exists(dir)) 
        {
            Directory.CreateDirectory(dir);
        }
        string json = JsonUtility.ToJson(gameData);
        File.WriteAllText(dir + fileName,json);
    }
    public static GameData LoadMethod()
    {
        GameData gameData = new GameData();
        string fullDir = Application.persistentDataPath + directory + fileName;
        if (!File.Exists(fullDir))
        {
            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(fullDir,json);
            gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(fullDir));
        }
        else
        {
            gameData = JsonUtility.FromJson<GameData>(File.ReadAllText(fullDir));
        }
        return gameData;
    }
}