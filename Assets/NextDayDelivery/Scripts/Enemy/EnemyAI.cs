using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public GameObject player;
    [Header("Player Lost")]
    [SerializeField]
    private float continueToFollowTime;
    [SerializeField]
    private float lostSearchTime;
    [SerializeField]
    public float playerLostAngularSpeed;
    [Header ("Patrol")]
    public NavMeshAgent agent;
    public GameObject[] patrolPoints;
    [SerializeField]
    private int currentPatrolPoint;


    private FOVDetection fOVDetection;
    private Vector3 startingPos;

    [SerializeField]
    private State state;
    private enum State
    {
        Patrol,
        ChaseTarget,
        TargetLost,
    }

    private void Awake()
    {
        fOVDetection = GetComponent<FOVDetection>();
    }

    private void Start()
    {
        startingPos = this.transform.position;
        state = State.Patrol;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Patrol:
                Patrol();
                PlayerInSight();
                break;
            case State.ChaseTarget:
                FollowPlayer();
                break;
            case State.TargetLost:
                PlayerLost();
                break;
        }
    }

    private void PlayerInSight()
    {
        lostSearchTime = 5f;
        continueToFollowTime = 5f;
        if (fOVDetection.isInFov)
        {
            state = State.ChaseTarget;
        }
    }

    private void Patrol()
    {
        agent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
        if(Vector3.Distance(this.transform.position, patrolPoints[currentPatrolPoint].transform.position) < 0.6f)
        {
            Debug.Log("Running");
            currentPatrolPoint++;
            if (currentPatrolPoint == patrolPoints.Length)
            {
                currentPatrolPoint = 0;
            }
            agent.SetDestination(patrolPoints[currentPatrolPoint].transform.position);
        }
    }

    private void FollowPlayer()
    {
        if (fOVDetection.isInFov)
        {
            agent.SetDestination(player.transform.position);
        }
        else if (!fOVDetection.isInFov)
        {

            if (continueToFollowTime <= 0)
            {
                state = State.TargetLost;
            }
            else
            {
                agent.SetDestination(player.transform.position);
                continueToFollowTime -= Time.deltaTime;
            }
        }
    }

    private void PlayerLost()
    {
        

        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) > 0.5f)
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
            Vector3 targetDirection = fOVDetection.playerLastKnownPos - this.transform.position;
            float singleStep = playerLostAngularSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, singleStep, 0.0f).normalized;
            this.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            if (lostSearchTime <= 0)
            {
                state = State.Patrol;
            }
            else
            {
                this.transform.Rotate(Vector3.up * playerLostAngularSpeed * Time.deltaTime);
                lostSearchTime -= Time.deltaTime;
            }
        }
    }
}
