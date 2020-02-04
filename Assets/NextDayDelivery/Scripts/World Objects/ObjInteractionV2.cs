using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteractionV2 : MonoBehaviour
{
    [SerializeField]
    private float throwForce = 600f;

    [SerializeField]
    private GameObject tempParent;

    [SerializeField]
    private bool pickedUp = false;

    public LayerMask pickMask;

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            PickUpObject();
        }
        Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.blue);
    }
    private void PickUpObject()
    {
        RaycastHit pickUpable;
        {
            if (Physics.Raycast(transform.position, transform.forward, out pickUpable, 1.5f, pickMask))
            {
                Debug.Log("Picked Up");
                pickUpable.collider.GetComponent<Rigidbody>().detectCollisions = false;
                pickUpable.collider.transform.SetParent(tempParent.transform);
                pickUpable.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pickUpable.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }
    private void OnMouseUpAsButton()
    {
        //Checks that the player isn't holding an object and if they are close to the object.
        if (!pickedUp)
        {
            //Disbales gravity so that the object doesn't fall while in the players hands. 
            pickedUp = true;
            pickUpable.collider.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

        }

        //Drops the object.
        else if (isHolding)
        {
            isHolding = false;
        }
    }
}
