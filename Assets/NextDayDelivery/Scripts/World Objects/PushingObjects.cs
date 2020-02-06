using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingObjects : MonoBehaviour
{
    public LayerMask pushMask;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            PushObject();
        }
        Debug.DrawRay(transform.position, transform.forward * 2f, Color.yellow);
    }
    void PushObject()
    {
        RaycastHit pushable;

        if (Physics.Raycast(transform.position, transform.forward, out pushable, 2f, pushMask))
        {
            pushable.collider.gameObject.GetComponent<Rigidbody>().AddForce((pushable.transform.position - this.transform.position).normalized * 15, ForceMode.Force);
        }
    }
}
