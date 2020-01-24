using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandCheck : MonoBehaviour
{
    //public Crouching stand;
    //void Update()
    //{
    private void OnCollisionEnter(Collision collision)
    {
        //stand.CrouchBlock();
    }

    private void OnCollisionExit(Collision collision)
    {
        //stand.NotCrouchBlock();
    }
}
    //}


