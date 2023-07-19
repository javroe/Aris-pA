using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 7.5f;
    public float walkSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    
    private bool isSprinting = false;
    

    Vector2 movement;

    // Update is called once per frame
    void Update() // input
    {
        movement.y = Input.GetAxisRaw("Vertical");
        movement.x = Input.GetAxisRaw("Horizontal");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // basically makes your movement speed constant
        Vector2 movementDirection = new Vector2(movement.x, movement.y).normalized; //fixes diagonal movement from being 1.414 times faster (unity square root smth)
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = sprintSpeed;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = walkSpeed;
        }

        float currentSpeed = isSprinting ? sprintSpeed : moveSpeed;
        

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate() // movement
    {    
        
    }
}


