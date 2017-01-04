using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadPlayer
{

    public static void save(string name, PlayerStatistics playerState)
    {

        string pathFile;

        if (!Directory.Exists(Application.persistentDataPath + "/Saves"))
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");

        pathFile = "/Saves/playerInfo_" + name + ".dat";

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file;

        if (File.Exists(Application.persistentDataPath + pathFile))
        {
            //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log 
            //if you want to know where save games are located
            file = File.Open(Application.persistentDataPath + pathFile, FileMode.Open); //you can call it anything you want
        }
        else
        {
            file = File.Create(Application.persistentDataPath + pathFile);
        }

        Debug.Log(GameManager.instance.playerState.lastDateTime);

        bf.Serialize(file, playerState);
        file.Close();
    }

    public static void load(string name, PlayerStatistics playerState)
    {
        string pathFile;

        pathFile = "/Saves/playerInfo_" + name + ".dat";

        if (File.Exists(Application.persistentDataPath + pathFile))
        {
            Debug.Log(GameManager.instance.playerState.lastDateTime);

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + pathFile, FileMode.Open);
            GameManager.instance.playerState = (PlayerStatistics)bf.Deserialize(file);
            file.Close();

            Debug.Log(GameManager.instance.playerState.lastDateTime);
        }
    }
}