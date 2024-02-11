using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurruntVector = transform.position;
    }
    public float Threshold = 0.00005f;
    public Animator animator;
    public Vector3 CurruntVector;
    public float s = 0;
    public float x = 0;
    public float y = 0;
    public float detx = 0;
    public float dety = 0;

    // Update is called once per frame

    void FixedUpdate()
    {
        
        detx = transform.position.x - CurruntVector.x;
        dety = transform.position.y - CurruntVector.y;

        if (detx > dety)
        {
            if (detx > Threshold)
            {
                s = 1;
                x = 1;
                y = 0;
            }
            else if (detx < -1*Threshold)
            {
                s = 1;
                x = -1;
                y = 0;
            }
        }
        else
        {
            if (dety > Threshold)
            {
                s = 1;
                x = 0;
                y = 1;
            }
            else if (dety < -1 * Threshold)
            {
                s = 1;
                x = 0;
                y = -1;
            }
        }
        if(transform.position == CurruntVector)
        {
            s = 0;
            x = 0;
            y = 0;
        }
        CurruntVector = transform.position;

        animator.SetFloat("Horizontal", y);
        animator.SetFloat("Vertical", x);
        animator.SetFloat("Speed", s);
    }
}
