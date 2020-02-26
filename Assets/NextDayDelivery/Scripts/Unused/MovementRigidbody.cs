using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRigidbody : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField]
    private float mouseSensitivity = 100f;

    float speed = 0f;

    [SerializeField]
    private float walkSpeed = 0f;

    [SerializeField]
    private float crouchSpeed = 0f;

    [SerializeField]
    private float runSpeed = 0f;

    void FixedUpdate()
    {
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

        //rb.AddForce((transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime), ForceMode.VelocityChange);
        rb.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime));
        //= new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0.0f, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
