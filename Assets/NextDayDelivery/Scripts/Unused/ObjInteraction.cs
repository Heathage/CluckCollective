using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    //How much force the player throws with. 
    public float throwForce = 600;
    //Sets position of pickup when it is dropped.
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    //Trying a sound thing - Pls don't kill me James
    public bool wasThrown = false;

    public float dropDistance = 0f;
    public float pickUpDistance = 0f;

    void Update()
    {
        //Tracks distance between the player and the pickup.
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        //Drops the held item if the distance grows more than specified.
        if (distance >= dropDistance)
        {
            isHolding = false;
        }

        //Whilst the item is being held, velocities are disabled.
        //The object becomes a child of the 
        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform, true);


            //Allows the player to throw the item, only when it is held.
            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
                wasThrown = true;
            }
        }

        //Drops the object where it is currently held.
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    //Allows the player to pick up and drop the object. Only if they are close enough.
    private void OnMouseUpAsButton()
    {
        //Checks that the player isn't holding an object and if they are close to the object.
        if ((!isHolding) && (distance <= pickUpDistance))
        {
            //Disbales gravity so that the object doesn't fall while in the players hands. 
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

        }

        //Drops the object.
        else if (isHolding)
        {
            isHolding = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {

    }
    //Resets the position of the object to the centre of the screen if it is knocked off centre by a collision. 
    //private void OnCollisionExit(Collision collision)
    //{
    //item.transform.localPosition = new Vector3(0, 0, 0);
    //}
}
