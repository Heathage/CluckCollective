using UnityEngine;

public class Leaning : MonoBehaviour
{
    public Crouching isCrouched;

    public float leanDistance = 1f;
    public float leanAngle = 30f;
    public float leanSpeed = 0.1f;

    float leanRightDistance;
    float leanLeftAngle;
    float leanLeftDistance;
    float leanRightAngle;

    float camHeight = 1.4f;

    void Start() 
    {
        leanRightDistance = leanDistance;
        leanLeftAngle = leanAngle;
        leanLeftDistance = leanDistance * -1;
        leanRightAngle = leanAngle * -1;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 0, 0), leanSpeed);
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localPosition = new Vector3(0, camHeight, 0);
        }

        else if (Input.GetKey("e"))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, new Quaternion(0f, 0f, leanRightAngle, 100f), leanSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(leanRightDistance, camHeight, 0), leanSpeed);
        }

        else if (Input.GetKeyUp("e"))
        {
            transform.localPosition = new Vector3(0, camHeight, 0);
        }
        else if (Input.GetKey("q"))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, new Quaternion(0f, 0f, leanLeftAngle, 0f), leanSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(leanLeftDistance, camHeight, 0), leanSpeed);
        }
        else if (Input.GetKeyUp("q"))
        {
            transform.localPosition = new Vector3(0, camHeight, 0);
        }
        
    }
}
