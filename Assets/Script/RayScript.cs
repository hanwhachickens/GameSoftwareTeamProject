using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayScript : MonoBehaviour
{
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool hitCheck(float distance, Vector2 wp, Vector2 playerPositon)
    {
        //Vector2 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Ray2D ray = new Ray2D(wp, playerPositon);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, distance);

        if(hit)
            return true;

        else return false;
    }
}
