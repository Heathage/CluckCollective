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

    Vector3 objectPos;

    public LayerMask pickMask;

    RaycastHit pickUpable;

    // Update is called once per frame
    void Update()
    {
        if (pickedUp == true)
        {
            PickUpObject();

            if (Input.GetMouseButtonDown(1))
            {
                pickUpable.collider.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                pickedUp = false;
            }
        }
        else
        {
            //DropObject();
        }
        Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.blue);
    }
    private void PickUpObject()
    {
        Debug.Log("Picked Up");
        pickUpable.collider.transform.SetParent(tempParent.transform);
        pickUpable.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
        pickUpable.collider.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    //private void DropObject()
    //{
    //    objectPos = pickUpable.collider.transform.position;
    //    pickUpable.collider.transform.SetParent(null);
    //    pickUpable.collider.GetComponent<Rigidbody>().useGravity = true;
    //    pickUpable.transform.position = objectPos;
    //}

    private void OnMouseUpAsButton()
    {
        //Checks that the player isn't holding an object and if they are close to the object.
        if (!pickedUp)
        {
            //Disbales gravity so that the object doesn't fall while in the players hands. 
            pickedUp = true;
            pickUpable.collider.GetComponent<Rigidbody>().useGravity = false;
            pickUpable.collider.GetComponent<Rigidbody>().detectCollisions = false;
        }

        //Drops the object.
        else if (pickedUp)
        {
            pickedUp = false;
        }
    }
}
