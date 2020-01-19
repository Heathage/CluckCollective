using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInteraction : MonoBehaviour
{
    float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    void Update()
    {
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if(distance >= 3f)
        {
            isHolding = false;
        }

        if (isHolding)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }

        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    private void OnMouseUpAsButton()
    {
        if ((!isHolding) && (distance <= 3f))
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

        }

        else if (isHolding)
        {
            isHolding = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (isHolding)
        {
            item.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
