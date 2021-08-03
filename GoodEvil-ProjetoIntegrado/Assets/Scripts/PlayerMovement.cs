using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;

    private float lastDirection;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //Setando direção do idle
        lastDirection = CheckDirection();
        if(lastDirection != -1)
        {
            animator.SetFloat("LastDirection", lastDirection);
        }
    }

    float CheckDirection()
    {
        if (movement.x > 0)
        {
            return 1; //Right
        }
        else if (movement.y > 0)
        {
            return 0; //Up
        }
        else if (movement.x < 0)
        {
            return 3; //Left
        }
        else if (movement.y < 0)
        {
            return 2; //Down
        }
        return -1; //Não esta mais movendo, ou seja, lastDirection ja foi salvo
    }

}