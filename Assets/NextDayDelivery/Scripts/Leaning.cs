using UnityEngine;

public class Leaning : MonoBehaviour
{
    public float leanRightAngle = 0f;
    public float leanRightDistance = 0f;
    public float leanLeftAngle = 0f;
    public float leanLeftDistance = 0f;
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Debug.Log("R");
            
            transform.localRotation = Quaternion.Euler(0f, 0f, leanRightAngle);
            transform.localPosition = new Vector3(leanRightDistance, 1.77f, 0);
        }

        else if (Input.GetKeyUp("r"))
        {
            transform.localPosition = new Vector3(0, 1.77f, 0);
        }
        else if (Input.GetKey("q"))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, leanLeftAngle);
            transform.localPosition = new Vector3(leanLeftDistance, 1.77f, 0);
        }
        else if (Input.GetKeyUp("q"))
        {
            transform.localPosition = new Vector3(0, 1.77f, 0);
        }
        
    }
}
