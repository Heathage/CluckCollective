using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [Header("Player Lost")]
    [SerializeField]
    private float continueToFollowTime;
    [SerializeField]
    private float lostSearchTime;
    [Range (45, 180)][SerializeField]
    private float playerLostAngularSpeed;
    [Header ("Patrol")]
    public NavMeshAgent agent;
    [Tooltip ("when the ground is at y = 0 put the patrol point on y = 2. This makes sure that the AI can see the patrol point and detect it.")][SerializeField]
    private GameObject[] patrolPoints;
    [SerializeField]
    private int currentPatrolPoint;


    private FOVDetection fOVDetection;

    [SerializeField]
    public State state;
    public enum State
    {
        Patrol,
        ChaseTarget,
        TargetLost,
        Sound,
    }

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        fOVDetection = this.GetComponent<FOVDetection>();
        
    }

    private void Start()
    {
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
            case State.Sound:
                GoToSmallSound();
                break;
        }
    }

    private void PlayerInSight()
    {
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
            //Debug.Log("Running");
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
            continueToFollowTime = 5f;
            lostSearchTime = 5f;
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

        //fOVDetection.playerLastKnownPos.y = 2f;
        //lostSearchTime = 5f;
        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) < 4f)
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
        else
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
        }
    }
    private void GoToSmallSound()
    {
        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) > 3f)
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
        }
        else
        {
            lostSearchTime = 5f;
            state = State.TargetLost;
        }
    }

}
