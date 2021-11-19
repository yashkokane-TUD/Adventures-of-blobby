using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public SaveData activeSave;
    public static SaveManager instance;
    public bool hasloaded = false;
   // public Vector3 resPt;
    public bool saveExists = false;

    //public GameObject player;
    //public GameObject[] saveobjects;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        //Load();
    }

 

    public void Save()
    {
        string datapath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(datapath + "/" + activeSave.saveName+".save",FileMode.Create);
        serializer.Serialize(stream,activeSave);
        stream.Close();
        Debug.Log("save created");
        saveExists = true;
    }

    public void overwriteSave()
    {
            string datapath = Application.persistentDataPath;
            if (System.IO.File.Exists(datapath + "/" + activeSave.saveName + ".save"))
            {
                var serializer = new XmlSerializer(typeof(SaveData));
                var stream = new FileStream(datapath + "/" + activeSave.saveName + ".save", FileMode.Create);
                serializer.Serialize(stream, activeSave);
                stream.Close();
                Debug.Log("save overwrite");
            }
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            
            Debug.Log("File Loaded");
            SceneManager.LoadScene("level-1");  
            hasloaded = true;
        }
        //resPt = player.transform.position;
        if (hasloaded)
        {
            Debug.Log("file loaded");
            //lives = SaveManager.instance.activeSave.lives;
            //HealthManager.PlayerHP = instance.activeSave.HP;
            //player.transform.position = instance.activeSave.lastCheckPoint;
            //LifeManager.LifeCounter = instance.activeSave.lives;
            //Debug.Log("health mang "  + HealthManager.PlayerHP);
            Debug.Log("save hp " + SaveManager.instance.activeSave.HP);
        }

        

    }

    public void DeleteSave()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName = "gameSave";
    public Vector3 resPos;
    //public bool doorOpen;
    public Vector3 lastCheckPoint;
    public int lives;
    public int HP;
    public int potionsR;
    public int potionsB;
}
