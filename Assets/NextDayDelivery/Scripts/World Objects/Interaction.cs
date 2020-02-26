using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField]
    private float playerReach = 0f;

    public bool holding = false;

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * playerReach, Color.black);

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit, playerReach))
            {
                hit.collider.gameObject.SendMessage("Interact");
            }
        }
    }
}
