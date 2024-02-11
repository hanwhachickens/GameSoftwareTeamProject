using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    void Update()
    {
        movement.x = -1*Input.GetAxisRaw("Horizontal");
        movement.y = -1*Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        //Debug.Log(transform.position);
        
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(movement.x, movement.y, 0) * Time.fixedDeltaTime * moveSpeed);
        //rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);
    }
}
