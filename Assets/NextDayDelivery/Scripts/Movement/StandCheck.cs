using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandCheck : MonoBehaviour
{
    //public Crouching stand;
    //void Update()
    //{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Blocked");
        //stand.CrouchBlock();
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Unblocked");
        //stand.NotCrouchBlock();
    }
}
    //}


