using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Datamanager : MonoBehaviour
{
    string extensionFile = ".gamedata";
    public void SaveData(GameData gameData)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create($"{Application.persistentDataPath}/saves{extensionFile}");
        bf.Serialize(file, gameData);
        file.Close();
        Debug.Log($"Saved in path: {Application.persistentDataPath}/saves{extensionFile}");
    }
}
