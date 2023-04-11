using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using TMPro;

public class SaveGame : MonoBehaviour
{
    public static int scoreLvL = 1;
    public static float powerClick;

    [System.Serializable]
    public class PlayerData
    {
        public int intToLvL;
        public float floatToPowerClick;
    }
    [SerializeField] PlayerData data;

    public void StartData()
    {
        PlayerData data = new PlayerData();
        data.intToLvL = scoreLvL;
        data.floatToPowerClick = powerClick;
        SaveData(data);
    }

    public void EndData()
    {
        PlayerData loadedData = LoadData();
        if (loadedData != null)
        {
            scoreLvL = loadedData.intToLvL;
            powerClick = loadedData.floatToPowerClick;
        }
    }

    // Сохранение данных в файл
    public void SaveData(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/player.dat");
        bf.Serialize(file, data);
        file.Close();
    }

    // Загрузка данных из файла
    public PlayerData LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/player.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return null;
        }
    }
}