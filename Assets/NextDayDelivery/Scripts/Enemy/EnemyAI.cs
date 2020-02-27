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
    [SerializeField]
    protected Vector3 rotationSpeed;
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
        LostRotation,
        ShootTarget,
    }

    private void Awake()
    {
        agent = this.GetComponent<NavMeshAgent>();
        fOVDetection = this.GetComponent<FOVDetection>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        
    }

    private void Start()
    {
        rotationSpeed = new Vector3(0f, 100f, 0f);
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
                GoToSound();
                break;
            case State.LostRotation:
                LostRotation();
                break;
            case State.ShootTarget:
                ShootTarget();
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
            if (fOVDetection.canShoot)
            {
                state = State.ShootTarget;
            }
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
        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) < 5f)
        {
            agent.SetDestination(this.transform.position);
            state = State.LostRotation;
        }
        else
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
        }
    }
    private void LostRotation()
    {
        if (lostSearchTime <= 0)
        {
            state = State.Patrol;
        }
        else
        {
            Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            lostSearchTime -= Time.deltaTime;
        }
    }

    private void GoToSound()
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



    private void ShootTarget()
    {
        if (!fOVDetection.canShoot)
        {
            state = State.ChaseTarget;
        }
    }
}
