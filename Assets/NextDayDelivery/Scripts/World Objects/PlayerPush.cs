using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    public Movement moveSpeed;

    private float speed;

    void Update()
    {
        speed = moveSpeed.speed;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //no rigidbody
        if (body == null || body.isKinematic)
            return;

        //We don't want to push objects below us.
        if (hit.moveDirection.y < -0.3f)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDir * speed;
    }
}
