using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator animator;
    private bool moving;

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Animate();        
    }

    // FixedUpdate is called a static 50 times per second
    void FixedUpdate()
    {
        // Movement handled here
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void GetInput() {
        // Input handled here
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Animate() {
        

        if(movement.magnitude > 0.1f || movement.magnitude < -0.1f) {
            moving = true;
        } else {
            moving = false;
        }

        if(moving) {
            // Animation parameters handled here
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            
        }

        animator.SetBool("Moving", moving);
        
    }
}
