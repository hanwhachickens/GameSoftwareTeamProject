using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // Vector3 dir = Vector3.right * h + Vector3.up * v;
        // Vector3.right = (1, 0, 0) / Vector3.up = (0, 1, 0)
        Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate(dir * speed * Time.deltaTime);
        // P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
