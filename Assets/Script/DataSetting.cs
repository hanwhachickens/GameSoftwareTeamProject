using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSetting : MonoBehaviour
{   
    public void Start()
    {
        GameObject Player = GameObject.Find("Player");
        
        // DataController.Instance.LoadGameData();
        Player.transform.position = DataController.Instance.gameData.position;
        Player.GetComponent<PlayerStat>().SetHealth(DataController.Instance.gameData.lastHealth);
        Player.GetComponent<PlayerStat>().healthBar.SetHealth(DataController.Instance.gameData.lastHealth);
        // Player.GetComponent<PlayerStat>().isDelay = DataController.Instance.gameData.lastDelay;
    }
}
