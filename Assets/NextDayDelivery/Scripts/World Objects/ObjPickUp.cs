using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    public MouseLook freezeCam;

    [SerializeField]
    private bool holding = false;
    [SerializeField]
    private bool inspecting = false;

    public float holdDistance = 0f;

    

    //check to see if player can pick up item.
    //assign a button to player to pick up.
    //assign a button for player to throw
    //assign a button for the player to rotate the object
    //Fix the object to a position when held, no gravity.
    //Make it so that they can be throw with decent force
    //Rotate with mouse.
    //Stop the player looking around when rotating. 

}
