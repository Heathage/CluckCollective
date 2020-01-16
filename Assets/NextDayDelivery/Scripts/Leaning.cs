using UnityEngine;

public class Leaning : MonoBehaviour
{
    public KeyCode leanRightKey = KeyCode.R;
    public KeyCode leanLeftKey = KeyCode.Q;
    void Update()
    {
        if (Input.GetKey(leanRightKey))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }

        else if (Input.GetKey(leanLeftKey))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else
        {

        }
    }
}
