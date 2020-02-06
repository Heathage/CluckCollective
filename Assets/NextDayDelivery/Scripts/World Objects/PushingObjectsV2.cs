using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingObjectsV2 : MonoBehaviour
{
    void OnCollisionStay(Collision other)
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            push();
        }
        else
        {
            noPush();
        }
    }

    private void push()
    {
        Debug.Log("Sucess");
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotationY;
    }

    private void noPush()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}

    //public LayerMask pushMask;

    //void Update()
    //{
    //    if (Input.GetKey(KeyCode.Mouse0))
    //    {
    //        PushObject();
    //    }
    //    else
    //    {
    //    }
    //    Debug.DrawRay(transform.position, transform.forward * 2f, Color.blue);
    //}
    //void PushObject()
    //{
    //    RaycastHit pushable;

    //    if (Physics.Raycast(transform.position, transform.forward, out pushable, 2f, pushMask))
    //    {
    //        Debug.Log("Sucess");
    //        pushable.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    //        pushable.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    //    }
    //    else
    //    {
    //        pushable.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
    //        pushable.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;
    //    }
    //}

