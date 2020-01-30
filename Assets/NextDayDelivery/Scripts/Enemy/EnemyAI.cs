using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float angularSpeed;
    public float speed;
    public float searchTime;
    public float playerLostAngularSpeed;
    public NavMeshAgent agent;

    private FOVDetection fOVDetection;
    [SerializeField]
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
                ResetPosition();
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
        searchTime = 5f;
        if (fOVDetection.isInFov)
        {
            state = State.ChaseTarget;
        }
    }

    private void FollowPlayer()
    {
        if (fOVDetection.isInFov)
        {
            //this.transform.position = Vector3.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            agent.SetDestination(player.position);
            Vector3 targetDirection = player.position - this.transform.position;
            float singleStep = angularSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, singleStep, 0.0f);
            this.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else if (!fOVDetection.isInFov)
        {
            state = State.TargetLost;
        }
    }

    private void PlayerLost()
    {
        

        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) > 0.2f)
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
            Vector3 targetDirection = fOVDetection.playerLastKnownPos - this.transform.position;
            float singleStep = angularSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, singleStep, 0.0f).normalized;
            this.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            if (searchTime <= 0)
            {
                state = State.Patrol;
            }
            else
            {
                this.transform.Rotate(Vector3.up * playerLostAngularSpeed * Time.deltaTime);
                searchTime -= Time.deltaTime;
            }
        }
    }

    private void ResetPosition()
    {
        if (Vector3.Distance(this.transform.position, startingPos) > 0.2f)
        {
            agent.SetDestination(startingPos);
            Vector3 targetDirection = startingPos - this.transform.position;
            float singleStep = angularSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(this.transform.forward, targetDirection, singleStep, 0.0f).normalized;
            this.transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            PlayerInSight(); 
        }
    }
}
