using UnityEngine;

public class Leaning : MonoBehaviour
{
    public float leanDistance = 1f;
    public float leanAngle = 30f;

    float leanRightDistance;
    float leanLeftAngle;
    float leanLeftDistance;
    float leanRightAngle;

    float camHeight = 0.6f;

    void Start() 
    {
        leanRightDistance = leanDistance;
        leanLeftAngle = leanAngle;
        leanLeftDistance = leanDistance * -1;
        leanRightAngle = leanAngle * -1;
    }
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Debug.Log("R");
            
            transform.localRotation = Quaternion.Euler(0f, 0f, leanRightAngle);
            transform.localPosition = new Vector3(leanRightDistance, camHeight, 0);
        }

        else if (Input.GetKeyUp("r"))
        {
            transform.localPosition = new Vector3(0, camHeight, 0);
        }
        else if (Input.GetKey("q"))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, leanLeftAngle);
            transform.localPosition = new Vector3(leanLeftDistance, camHeight, 0);
        }
        else if (Input.GetKeyUp("q"))
        {
            transform.localPosition = new Vector3(0, camHeight, 0);
        }
        
    }
}
