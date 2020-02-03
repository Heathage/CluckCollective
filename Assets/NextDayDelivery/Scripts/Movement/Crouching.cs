﻿using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    public float crouching = 0f;
    public float crouchCam = 0f;

    public float crouchSpeed = 0.1f;

    public float standing = 0f;
    public float standCam = 0f; 

    public bool crouched = false;
    public bool crouchBlocked = false;

    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || (crouchBlocked == true))
        {
            crouch();
        }

        else if ((crouchBlocked == false) && (crouched == false))
        {
            unCrouch();
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouched = false;
        }

        else if (crouchBlocked == false)
        {
            unCrouch();
        }

        crouchBlocked = IsCeilingAbove(1.5f);
    }

    private void crouch()
    {
        crouched = true;
        CharacterController.center = new Vector3(0, -1, 0);
        CharacterController.height = crouching;
    }

    private void unCrouch()
    {
        crouched = false;
        CharacterController.center = new Vector3(0, 0, 0);
        CharacterController.height = standing;
    }

    private bool IsCeilingAbove(float distance)
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);
        return Physics.Raycast(transform.position, transform.up, distance);
    }

    public void CrouchBlock()
    {
        crouchBlocked = true;
    }

    public void NotCrouchBlock()
    {
        crouchBlocked = false;
    }

        //    if (Input.GetKey(KeyCode.LeftControl))
        //{
        //    transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 0, 0), leanSpeed);
        //}

        //if (Input.GetKeyUp(KeyCode.LeftControl))
        //{
        //transform.localPosition = new Vector3(0, camHeight, 0);

        //}
}
