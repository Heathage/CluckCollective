using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    Vector3 objectPos;

    [Header("Camera freeze reference")]
    public MouseLook freezeCam;

    [Header("Player Object Interaction")]
    [SerializeField]
    private bool holding = false;
    [SerializeField]
    private bool inspecting = false;

    [Header("Object References")]
    [SerializeField]
    public GameObject item;
    [SerializeField]
    public GameObject tempParent;

    [Header("The Yeet")]
    [SerializeField]
    private float throwForce = 1000;
    public bool wasThrown = false;

    [Header("Temporary")]
    public GameObject key;
    public DoorRegular door;
    public GameObject uielement;

    public void Interact()
    {
        Debug.Log("Interacted");

        //Picks up item if player isn't holding anything and disbales the gravity on object.
        if (holding == false)
        {
            holding = true;
            item.GetComponent<Rigidbody>().useGravity = false;

            //Checks to see if the object is a key, unlocks the door, and then sets item active state to false.
            if (item.gameObject == key)
            {
                uielement.SetActive(true);
                Debug.Log("UNLOCKED");
                door.Locked = false;
                item.gameObject.SetActive(false);
            }
        }

        //Drops the item if it is currently held.
        //Unfreezes the camera if the player was in the middle of inspecting.
        else if (holding == true)
        {
            holding = false;
            freezeCam.canLook = true;
        }
    }

    void Update()
    {
        if (holding)
        {
            heldItem();

            if (Input.GetMouseButtonDown(1))
            {
                yeet();
            }

            if (Input.GetMouseButtonDown(2))
            {
                inspect();
            }

            if (inspecting)
            {
                rotate();
            }
        }

        else
        {
            dropped();
            inspecting = false;
        }
    }
    
    //Disables certain Rigidbody elements so that the object is held in place.
    void heldItem()
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //Sets the position of the item to the specified empty game object space for player held items.
        item.transform.SetParent(tempParent.transform, false);
        item.transform.localPosition = new Vector3(0, 0, 0);

        //Ensures the item is of a certain rotation when it is not being inspected.
        //Keeps player view clear.
        if (!inspecting)
        {
            item.transform.localRotation = Quaternion.Euler(170, 0, 0); 
        }
    }

    //Throws player held item.
    void yeet()
    {
        //Raises the item just before throwing for better throw distance and aim.
        item.transform.localPosition = new Vector3(0, 1, 0);
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
        holding = false;
        wasThrown = true;
    }

    //Drops the item in front of the player.
    //Returns rigidbody elements back to normal state.
    void dropped()
    {
        objectPos = item.transform.position;
        item.transform.SetParent(null);
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.transform.position = objectPos;
    }

    //Allows the player to rotate the held object.
    void inspect()
    {
        //Freezes the camera so the player can use the mouse to rotate the object. 
        if (!inspecting)
        {
            inspecting = true;
            freezeCam.canLook = false;
        }

        //Unfreezes the camera so the player can look around again.
        else
        {
            inspecting = false;
            freezeCam.canLook = true;
        }
    }

    //Allows the player to use the mouse to rotate the object. 
    private void rotate()
    {
        item.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0), Space.Self);
    }
}
