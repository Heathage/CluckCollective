using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPickUp : MonoBehaviour
{
    Vector3 objectPos;

    public MouseLook freezeCam;

    [SerializeField]
    private bool holding = false;
    [SerializeField]
    private bool inspecting = false;

    [SerializeField]
    public GameObject item;
    [SerializeField]
    public GameObject tempParent;

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

        if (holding == false)
        {
            holding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            Debug.Log("True");

            if (item.gameObject == key)
            {
                uielement.SetActive(true);
                Debug.Log("UNLOCKED");
                door.Locked = false;
                item.gameObject.SetActive(false);
            }
        }

        else if (holding == true)
        {
            holding = false;
            Debug.Log("False");
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

    void heldItem()
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        item.transform.SetParent(tempParent.transform, false);
        item.transform.localPosition = new Vector3(0, 0, 0);

        if (!inspecting)
        {
            item.transform.localRotation = Quaternion.Euler(170, 0, 0); 
        }
    }

    void yeet()
    {
        item.transform.localPosition = new Vector3(0, 1, 0);
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
        holding = false;
        wasThrown = true;
    }

    void dropped()
    {
        objectPos = item.transform.position;
        item.transform.SetParent(null);
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        item.transform.position = objectPos;
    }

    void inspect()
    {
        if (!inspecting)
        {
            Debug.Log("Frozen");
            inspecting = true;
            freezeCam.canLook = false;
        }

        else
        {
            Debug.Log("Let it go!");
            inspecting = false;
            freezeCam.canLook = true;
        }
    }

    private void rotate()
    {
        item.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0), Space.Self);
    }
}
