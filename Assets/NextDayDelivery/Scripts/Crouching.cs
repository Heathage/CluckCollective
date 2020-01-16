using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    public float crouching = 0f;

    public float standing = 0f;

    public KeyCode crouchKey = KeyCode.C;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        if(Input.GetKey(crouchKey))
        {
            CharacterController.height = crouching;
        }
        else
        {
            CharacterController.height = standing;
        }
    }
}
