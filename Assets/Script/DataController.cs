using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

[Serializable]
public class GameData
{
    public Vector3 position;
    public int lastHealth = 3;
    // public Boolean lastDelay;
}

public class DataController : MonoBehaviour
{
    static GameObject container;
    static GameObject Container
    {
        get
        {
            return container;
        }
    }
    static DataController instance;
    public static DataController Instance
    {
        get
        {
            if(!instance)
            {
                container = new GameObject();
                container.name = "DataController";
                instance = container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(container);
            }
            return instance;
        }
    }


    public string GameDataFileName = ".json";

    public GameData gameData =  new GameData();
    
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        } 
    }
    public void SaveGameData()
    {
        GameObject player = GameObject.Find("Player");
        gameData.position = player.transform.position;
        gameData.lastHealth = player.GetComponent<PlayerStat>().currentHealth;
        // gameData.lastDelay = player.GetComponent<PlayerStat>().isDelay;
        string ToJsonData = JsonUtility.ToJson(gameData, true);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장 완료");
    }
    private void OnApplicationPause()
    {
        SaveGameData();
    }
}