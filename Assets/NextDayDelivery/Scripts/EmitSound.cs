using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSound : MonoBehaviour
{
    private Rigidbody rb;
    [Range (0, 50)]
    [SerializeField]
    private float sphereRadius;
    public LayerMask layerMask;

    public Vector3 origin;
    private Vector3 velocity;

    private EnemyAI enemy;
    private FOVDetection fOVDetection;
    private ObjInteraction objInteraction;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        objInteraction = this.gameObject.GetComponent<ObjInteraction>();
    }
    private void FixedUpdate()
    {
        velocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (objInteraction.wasThrown)
        {
            if (velocity.y <= 1)
            {
                origin = this.transform.position;


                Collider[] hits = Physics.OverlapSphere(origin, sphereRadius, layerMask, QueryTriggerInteraction.UseGlobal);
                int i = 0;
                while (i < hits.Length)
                {
                    if (hits[i].gameObject.GetComponent<EnemyAI>() != null)
                    {

                        enemy = hits[i].gameObject.GetComponent<EnemyAI>();
                        fOVDetection = hits[i].gameObject.GetComponent<FOVDetection>();

                        fOVDetection.playerLastKnownPos = origin;
                        fOVDetection.playerLastKnownPos.y += 1;
                        Destroy(this.gameObject);
                        enemy.state = EnemyAI.State.Sound;
                    }
                    i++;
                }
            }
        }
        
    }
}
