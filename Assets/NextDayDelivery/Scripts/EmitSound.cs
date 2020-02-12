using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSound : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        velocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (velocity.y <= 1)
        {
            Debug.Log("Sound");
        }
    }
}
