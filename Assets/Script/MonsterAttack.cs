using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{
    //public float distance;
    public float attackDelay;
    //public Transform target;

    //public GameObject monster;
    //public GameObject player;
    bool isDelay;
    

    // Start is called before the first frame update
    void Start()
    {
        attackDelay = 2;
        isDelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<MonsterStat>().damage);
        //distance = Vector3.Distance(monster.transform.position, player.transform.position);
        
        //if (distance <= 1)
        //{

        //    StartCoroutine(TargetAttack());
            
        //}
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);

            if (distance <= 1.5f)
                StartCoroutine(TargetAttack(other.GameObject()));
        }
    }


    IEnumerator TargetAttack(GameObject player)
    {
        if (player.GetComponent<PlayerStat>().GetUnBeatTime() == false)
        {
            if (isDelay == false)
            {
                isDelay = true;
                player.GetComponent<PlayerStat>().SetHealth(player.GetComponent<PlayerStat>().GetHealth() - GetComponent<MonsterStat>().damage);
                Debug.Log(player.name + " health : " + player.GetComponent<PlayerStat>().GetHealth());
                player.GetComponent<PlayerStat>().healthBar.SetHealth(player.GetComponent<PlayerStat>().GetHealth());
                player.GetComponent<PlayerStat>().SetUnBeatTime(true);
                StartCoroutine(player.GetComponent<GameManager>().CalcUnBeatTime());
                yield return new WaitForSeconds(attackDelay);
                isDelay = false;
            }
        }
    }
}
