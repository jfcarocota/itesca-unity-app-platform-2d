﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Datamanager : MonoBehaviour
{
    string extensionFile = ".gamedata";

    public void SaveData(GameData gameData)
    {
        string filePath = $"{Application.persistentDataPath}/saves{extensionFile}";
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(filePath);
        bf.Serialize(file, gameData);
        file.Close();
        Debug.Log($"Saved in path: {filePath}");
    }

    public GameData LoadData()
    {
        string filePath = $"{Application.persistentDataPath}/saves{extensionFile}";
        GameData gameData = new GameData();

        if(File.Exists(filePath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(filePath, FileMode.Open);
            gameData = bf.Deserialize(file) as GameData;
            file.Close();
        }

        return gameData;
    }
}