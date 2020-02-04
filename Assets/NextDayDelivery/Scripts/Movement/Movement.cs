using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    [SerializeField]
    private float walkSpeed = 0f;
    [SerializeField]
    private float crouchSpeed = 0f;
    [SerializeField]
    private float runSpeed = 0f;
    [SerializeField]
    private float gravity = 0f;

    public Transform groundCheck;
    public float groundDistance = 0f;
    public LayerMask groundMask;

    public LayerMask pushMask;

    Vector3 velocity;
    public bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        //Checks to see if player is crouching, adjusts speed to match.
        if (Input.GetKey(KeyCode.LeftControl))
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

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            PushObject();
        }

        Debug.DrawRay(transform.position, transform.forward * 2f, Color.red);

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
        Debug.Log(transform.forward);


        controller.Move(move * speed * Time.deltaTime);

        //Controls player fall speed. 
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void PushObject()
    {
        RaycastHit pushable;

        if (Physics.Raycast(transform.position, transform.forward, out pushable, 2f, pushMask))
        {
            pushable.collider.gameObject.GetComponent<Rigidbody>().AddForce((pushable.transform.position - this.transform.position).normalized * 15, ForceMode.Impulse);
        }
    }
}
