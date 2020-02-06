using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchingV2 : MonoBehaviour
{
    private Rigidbody rb;

    public float crouching = 0f;
    public float crouchCam = 0f;

    public float crouchSpeed = 0.1f;

    public bool crouched = false;
    public bool crouchBlocked = false;

    public GameObject Camera;

    void start()
    {
        crouched = false;
        crouchBlocked = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || (crouchBlocked == true))
        {
            crouch();
            //lowerCamera();
        }

        else if ((crouchBlocked == false) && (crouched == false))
        {
            unCrouch();
            //raiseCamera();
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouched = false;
        }

        else if (crouchBlocked == false)
        {
            unCrouch();
            //raiseCamera();
        }

        crouchBlocked = IsCeilingAbove(1.5f);
    }

    private void crouch()
    {
        crouched = true;
        gameObject.transform.localScale = new Vector3(0.7f, 0.3f, 0.7f);

    }

    private void unCrouch()
    {
        crouched = false;
        gameObject.transform.localScale = new Vector3(0.7f, 0.9f, 0.7f);
    }

    private bool IsCeilingAbove(float distance)
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);
        return Physics.Raycast(transform.position, transform.up, distance);
    }


}
