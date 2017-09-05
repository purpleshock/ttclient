using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameControl : MonoBehaviour {
    public static GameControl Control;
    const string saveFilename = "saveData.dat";


	public int myNum;

    void Awake()
    {
        if (Control == null)
        {
            DontDestroyOnLoad(gameObject);
            Control = this;
            Load();
        }
        else if (Control != this)
        {
            Destroy(gameObject);
        }
    }

    void Start(){

    }

    void Update(){

    }

    public void Save()
    {
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + saveFilename);

        UserData data = new UserData();

		data.num = myNum;

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");

        if (File.Exists(Application.persistentDataPath + "/" + saveFilename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + saveFilename, FileMode.Open);
            UserData data = (UserData)bf.Deserialize(file);

			myNum = data.num;

            file.Close();
        }
    }
}


[Serializable]
class UserData
{
	public int num;
}