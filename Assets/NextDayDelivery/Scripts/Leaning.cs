using UnityEngine;

public class Leaning : MonoBehaviour
{
    private CharacterController CharacterController;

    public float leanRight = 0f;

    public float leanLeft = 0f;

    public float noLean = 0f;

    public KeyCode leanRightKey = KeyCode.R;
    public KeyCode leanLeftKey = KeyCode.Q;

    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leanRightKey))
        {
            CharacterController.height = crouching;
        }
        else if (Input.GetKey(leanLeftKey))
        {
            CharacterController.height = standing;
        }
        else
        {

        }
    }
}
