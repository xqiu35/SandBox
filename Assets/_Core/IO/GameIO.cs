using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class FileName
{
    public const string MUSIC2D = "Music2D.dat";
    public const string VIEW_MODE = "ViewMode.dat";
}

public class GameIO : MonoBehaviour {

    public static void saveData(string fileName, object data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.OpenOrCreate);
        formatter.Serialize(file, data);
        file.Close();
    }

    public static T loadData<T>(string fileName)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
        T data = (T)formatter.Deserialize(file);
        file.Close();

        return data;
    }
}
