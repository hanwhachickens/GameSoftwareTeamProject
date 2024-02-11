using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class aggro : MonoBehaviour
{
    public GameObject Playerobj;
    public GameObject compo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Playerobj = GameObject.FindWithTag("Player");
        if (other.gameObject.name == "Player")
        {
            transform.GetComponentInParent<AIDestinationSetter>().target = Playerobj.transform;
        }
    }
}