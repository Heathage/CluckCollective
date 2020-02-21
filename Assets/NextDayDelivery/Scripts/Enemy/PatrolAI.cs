using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : EnemyAI
{
    protected override void Patrol()
    {
        agent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
        if (Vector3.Distance(this.transform.position, patrolPoints[currentPatrolPoint].transform.position) < 0.6f)
        {
            //Debug.Log("Running");
            currentPatrolPoint++;
            if (currentPatrolPoint == patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
            agent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
        }
    }
}
