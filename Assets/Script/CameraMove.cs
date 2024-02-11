using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    
    void LateUpdate()
    {
        // transform.position = new Vector3(target.position.x, target.position.y, -30f);
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * 5f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -30f);
    }
}
