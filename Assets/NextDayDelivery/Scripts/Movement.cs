using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    public float walkSpeed = 0f;
    public float crouchSpeed = 0f;
    public float runSpeed = 0f;
    public float gravity = 0f;

    public Transform groundCheck;
    public float groundDistance = 0f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Checks to see if player is crouching, adjusts speed to match.
        if (Input.GetKey(KeyCode.C))
        {
            speed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        //Checks to see if the player has hit the Ground layer while falling.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Resets the velocity when player hits the ground.
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Controls movement. 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Controls player fall speed. 
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
