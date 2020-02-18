using UnityEngine;

public class FOVDetection : MonoBehaviour
{
    [Tooltip("put the current player on the scence here")]
    [SerializeField]
    private GameObject player;
    [Header("Player Detection")]
    [Tooltip("Leave as Player and make sure the current player is on the Player layer")]
    [SerializeField]
    private LayerMask layerMask;
    [Range (5, 90)][SerializeField]
    private float maxAngle;
    [Range (5, 30)][SerializeField]
    private float maxRadius;
    [Header("Variables for other script to run")]
    public Vector3 playerLastKnownPos;
    public bool isInFov = false;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, fovLine1);
        Gizmos.DrawRay(transform.position, fovLine2);

        if (!isInFov)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * maxRadius);

        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
    }

    public bool InFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius, LayerMask layerMask)
    {
        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps, layerMask);

        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                if (overlaps[i].transform == target)
                {
                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {
                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {
                            if (hit.transform == target)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;
    }

    private void Update()
    {
        isInFov = InFOV(this.transform, player.transform, maxAngle, maxRadius, layerMask);
        if (isInFov)
        {
            playerLastKnownPos = player.transform.position;
        }

    }
}