using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    [Header("Player Lost")]
    [SerializeField]
    protected float continueToFollowTime;
    [SerializeField]
    protected float lostSearchTime;
    [Range (45, 180)][SerializeField]
    protected float playerLostAngularSpeed;
    [Header ("Patrol")]
    public NavMeshAgent agent;
    [Tooltip ("when the ground is at y = 0 put the patrol point on y = 2. This makes sure that the AI can see the patrol point and detect it.")][SerializeField]
    protected GameObject[] patrolPoints;
    [SerializeField]
    protected int currentPatrolPoint;
    protected Rigidbody rb;


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
        rb = this.gameObject.GetComponent<Rigidbody>();
        
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

    protected virtual void Patrol()
    {

    }

    private void FollowPlayer()
    {
        if (fOVDetection.isInFov)
        {
            continueToFollowTime = 8f;
            lostSearchTime = 5f;
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
