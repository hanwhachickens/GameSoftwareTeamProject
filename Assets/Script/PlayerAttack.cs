using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // public float distance;
    public float attackDelay;
    // public Transform target;

    // public GameObject monster;
    public GameObject player;
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
        //distance = Vector3.Distance(player.transform.position, monster.transform.position);

        //if (distance <= 2)
        //{

        //    StartCoroutine(TargetAttack());

        //}

    }

    void FixedUpdate()
    {
        //
    }

    public IEnumerator TargetAttack(Collider2D other)
    {
        if (isDelay == false)
        {
            isDelay = true;

            other.GetComponent<MonsterStat>().SetHealth(other.GetComponent<MonsterStat>().GetHealth() - player.GetComponent<PlayerStat>().damage);
            Debug.Log(other.name + " health : " + other.GetComponent<MonsterStat>().GetHealth());
            other.GetComponent<MonsterStat>().healthBar.SetHealth(other.GetComponent<MonsterStat>().GetHealth());
            yield return new WaitForSeconds(attackDelay);   
            isDelay = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        //Debug.Log("ÆÜÆÜÆÜ");
        //if (other.tag == "Monster")
        //    StartCoroutine(TargetAttack(other));
        //Debug.Log(other.tag);
        //if (other.tag == "NPC")
        //    Debug.Log("NPC ¤¾¤·");
    }
}
