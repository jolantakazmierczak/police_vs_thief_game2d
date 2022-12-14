using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWASD : MonoBehaviour
{
   public float moveSpeed = 10f;

    public Rigidbody2D rb;

    Vector2 movement;

    public Animator animator;



    void Start()
    {
        movement.x = 0;
        movement.y = 0;
    }

    // Update is called once per frame
    void Update()
    {


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement.y == 1 || movement.y == -1 || movement.x == 1 || movement.x == -1)
        {
            animator.SetFloat("lastMoveX", movement.x);
            animator.SetFloat("lastMoveY", movement.y);
        }


        rb.velocity = new Vector2 (movement.x * moveSpeed * Time.fixedDeltaTime, movement.y * moveSpeed * Time.fixedDeltaTime);

        if ( Input.GetKeyDown(KeyCode.W))
        {
            movement.y = 1;
        }
        if( Input.GetKeyDown(KeyCode.S))
        {
            movement.y = -1;
        }
        if( Input.GetKeyDown(KeyCode.A))
        {
            movement.x = -1;
        }
        if( Input.GetKeyDown(KeyCode.D))
        {
            movement.x = 1;
        }
        if( Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            movement.y = 0;
        }
        if( Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            movement.x = 0;
        }





    }




}
