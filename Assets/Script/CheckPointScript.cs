using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.IO;



[Serializable]
public class CheckPointData
{
    public Vector3 position;
    // public int lastHealth;
    // public Boolean lastDelay;
}



public class CheckPointScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GameDataFileName = ".json";
    public CheckPointData checkPointData = new CheckPointData();


    public void LoadCheckPointData()
    {
        string filePath = Application.persistentDataPath + "CheckData" + GameDataFileName;
        if (File.Exists(filePath))
        {
            Debug.Log("불러오기 성공");
            string FromJsonData = File.ReadAllText(filePath);
            checkPointData = JsonUtility.FromJson<CheckPointData>(FromJsonData);
        }
    }

    public void SaveCheckPointData()
    {
        string ToJsonData = JsonUtility.ToJson(checkPointData, true);
        string filePath = Application.persistentDataPath + "CheckData"+ GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
    }

    public void Save(Vector3 position)
    {
        checkPointData.position= position;
       

        SaveCheckPointData();
        // Debug.Log("저장완료, 현재 위치: " + DataController.Instance.gameData.position);
        Destroy(transform.parent.gameObject);
    }
}
