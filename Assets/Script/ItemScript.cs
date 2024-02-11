using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getPotion()
    {
        GameObject player = GameObject.Find("Player");
        int maxHealth = player.GetComponent<PlayerStat>().maxHealth;
        player.GetComponent<PlayerStat>().SetHealth(maxHealth);
        player.GetComponent<PlayerStat>().healthBar.SetHealth(player.GetComponent<PlayerStat>().GetHealth());
        Destroy(this.gameObject);
    }
}
