using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandCheck : MonoBehaviour
{
    public GameObject player;

    public bool blocked = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Blocked");
        Crouching test = player.GetComponent<Crouching>();
        test.crouchBlocked = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Unblocked");
        Crouching test = player.GetComponent<Crouching>();
        test.crouchBlocked = false;
     
    }
}


