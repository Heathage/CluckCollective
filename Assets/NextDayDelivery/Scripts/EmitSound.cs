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
            origin = this.transform.position;
            

            Collider[] hits = Physics.OverlapSphere(origin, sphereRadius, layerMask, QueryTriggerInteraction.UseGlobal);
            int i = 0;
            while (i < hits.Length)
            {
                if (hits[i].gameObject.GetComponent<EnemyAI>() != null)
                {
                    
                    EnemyAI enemy = hits[i].gameObject.GetComponent<EnemyAI>();
                    FOVDetection fOVDetection = hits[i].gameObject.GetComponent<FOVDetection>();
                    enemy.state = EnemyAI.State.Sound;
                    if(Vector3.Distance(enemy.enemy.transform.position, origin) > 3f)
                    {
                        enemy.agent.SetDestination(origin);
                        Debug.Log("Sound");
                    }
                    else
                    {
                        fOVDetection.playerLastKnownPos = origin;
                        fOVDetection.playerLastKnownPos.y += 1;

                        enemy.state = EnemyAI.State.TargetLost;
                    }
                    
                }
                i++;
            }
        }
    }
}
