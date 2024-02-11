using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float directionAD, directionWS;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        directionAD = Input.GetAxisRaw("Horizontal");
        directionWS = Input.GetAxisRaw("Vertical");
        PlayerToMove(directionAD, directionWS);
    }

    void PlayerToMove(float directionAD, float directionWS)
    {
        animator.SetBool("moving", true);
        if (directionAD > 0) // 오른쪽
        { 
            transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool("moveRight", true);
        }

        else if (directionAD < 0) // 왼쪽
        {
           transform.localScale = new Vector3(1, 1, 1);
           animator.SetBool("moveLeft", true);
        }

        else if (directionWS > 0) // 아래쪽
        {
            animator.SetBool("moveDown", true);
        }

        else if(directionWS < 0) // 위쪽
        {
            animator.SetBool("moveUp", true);
        }

        else
        {
            animator.SetBool("moving", false);
            animator.SetBool("moveRight", false);
            animator.SetBool("moveLeft", false);
            animator.SetBool("moveDown", false);
            animator.SetBool("moveUp", false);
        }

        transform.Translate(new Vector3(directionAD, directionWS, 0) * Time.deltaTime * 5f);
    }
}
