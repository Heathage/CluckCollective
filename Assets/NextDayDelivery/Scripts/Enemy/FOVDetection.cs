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
    [Range(5, 90)] [SerializeField]
    private float fovAngle;
    [Range(5, 30)] [SerializeField]
    private float fovRadius;
    [Header("Shooting Range")]
    [Range(5, 90)][SerializeField]
    private float shootingAngle;
    [Range(5, 30)][SerializeField]
    private float shootingRadius;

    [Header("Variables for other script to run")]
    public Vector3 playerLastKnownPos;
    public bool isInFov = false;
    public bool canShoot = false;

    private void OnDrawGizmos()
    {
        //Draws fov radius
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, fovRadius);
        //Draws shooting radius
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);

        Vector3 fovLine1 = Quaternion.AngleAxis(fovAngle, transform.up) * transform.forward * fovRadius;
        Vector3 fovLine2 = Quaternion.AngleAxis(-fovAngle, transform.up) * transform.forward * fovRadius;

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
        if (player != null)
        {
            Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized * fovRadius);
        }


        Gizmos.color = Color.black;
        Gizmos.DrawRay(transform.position, transform.forward * fovRadius);
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
        if(player != null)
        {
            isInFov = InFOV(this.transform, player.transform, fovAngle, fovRadius, layerMask);
            canShoot = InFOV(this.transform, player.transform, shootingAngle, shootingRadius, layerMask);
            if (isInFov)
            {
                playerLastKnownPos = player.transform.position;
            }
        }
    }
}