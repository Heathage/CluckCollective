using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Crouching crouched;

    [Header("Movement Speeds")]
    public float speed = 0f;
    [SerializeField]
    private float walkSpeed = 0f;
    [SerializeField]
    private float runSpeed = 0f;
    [SerializeField]
    private float gravity = 0f;

    [Header("Ground Checks")]
    public Transform groundCheck;
    public float groundDistance = 0f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Checks to see if player is crouching, adjusts speed to match.
        if ((Input.GetKey(KeyCode.LeftShift)) && (!crouched.crouched))
        {
            speed = runSpeed;
        }
        else if (!crouched.crouched)
        {
            speed = walkSpeed;
        }

        //Checks to see if the player has hit the Ground layer while falling.
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //Resets the velocity when player hits the ground.
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
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
