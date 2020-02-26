using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPushed : MonoBehaviour
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

    void OnCollisionExit(Collision other)
    {
        noPush();
    }

    private void push()
    {
        //Debug.Log("Sucess");
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
    }

    private void noPush()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }
}
