using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    Vector3 objectPos;

    //public MouseLook freezeCam;
    [SerializeField]
    private bool holding = false;
    [SerializeField]
    private bool inspecting = false;

    [SerializeField]
    public GameObject item;
    [SerializeField]
    public GameObject tempParent;

    private float distance = 2f;
    [SerializeField]
    private float dropDistance = 0;
    [SerializeField]
    private float throwForce = 600;
    public bool wasThrown = false;

    //public float holdDistance = 0f;

    public void Interact()
    {
        Debug.Log("Interacted");

        if(holding == false)
        {
            holding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("True");
            //pick up item
        }

        else if(holding == true)
        {
            holding = false;
            Debug.Log("False");
            //dont pick up item
        }
    }
    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);

        if (distance >= dropDistance)
        {
            holding = false;
        }

        if (holding)
        {
            heldItem();

            if (Input.GetMouseButtonDown(1))
            {
                yeet();
            }
        }

        else
        {
            dropped();
        }
    }

    void heldItem()
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.transform.SetParent(tempParent.transform, true);
    }

    void yeet()
    {
        item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
        holding = false;
        wasThrown = true;
    }

    void dropped()
    {
        objectPos = item.transform.position;
        item.transform.SetParent(null);
        item.GetComponent<Rigidbody>().useGravity = true;
        item.transform.position = objectPos;
    }


    //check to see if player can pick up item.
    //assign a button to player to pick up.
    //assign a button for player to throw
    //assign a button for the player to rotate the object
    //Fix the object to a position when held, no gravity.
    //Make it so that they can be throw with decent force
    //Rotate with mouse.
    //Stop the player looking around when rotating. 

}
