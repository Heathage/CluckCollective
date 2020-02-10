using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRegular : MonoBehaviour
{
    Animator anim;
    bool Opening = false;
    bool Closing = false;

    public bool open = false; //used to make the door start in point 2
    public float Point1; //first point, treated as a rotation or a position depending on UsePosInsteadOfRot
    public float Point2; //second point
    public bool UsePosInsteadOfRot = false; //switches between a rotation door or a vertical sliding door
    public bool Locked = false; //locks or unlocks the door
    public float Speed = 1f; //adjusts the door's opening speed



    void OnTriggerEnter()
    {
        //anim.SetBool("Open?", true);
        if (Opening == false && Closing == false)
        {
            if (Locked == true)
            {
                Debug.Log("Door is locked!");
            } 
            else if (open == false)
            {
                Opening = true;
            }
            else if (open == true)
            {
                //Closing = true;
            }
            
        }
    }

    void OnTriggerExit()
    {
        //anim.SetBool("Open?", false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //main animation component
        //this probably isn't the best way to do things hhhhh
        if (Opening == true)
        {
            if (UsePosInsteadOfRot == false)
            {
                //rotate from point 1 to point 2
                transform.localEulerAngles = Vector3.RotateTowards(transform.localEulerAngles, new Vector3(0f, 0f, 1f), 0.1f, 0.001f);
                
            } 
            else if (UsePosInsteadOfRot == true)
            {
                //move from point 1 to point 2
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, Point2, transform.localPosition.z), Speed);
            }
        }
        if (Closing == true)
        {
            if (UsePosInsteadOfRot == false)
            {
                //rotate from point 2 to point 1
                transform.localRotation = Quaternion.Lerp(transform.localRotation, new Quaternion(-90f, 0f, Point1, 90f), Speed);
            }
            else if (UsePosInsteadOfRot == true)
            {
                //move from point 2 to point 1
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(transform.localPosition.x, Point1, transform.localPosition.z), Speed);
            }
        }
    }
}
