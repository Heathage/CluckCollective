using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    private bool crouch = false;

    private float standing;

    [SerializeField] private float crouching = 0.9f;

    public KeyCode crouchKey = KeyCode.C;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        standing = CharacterController.height;
    }

    void Update()
    {
        if(Input.GetKey(crouchKey))
        {
            crouch = !crouch;

            CheckCrouch();
        }
    }

    void CheckCrouch()
    {
        if(crouch == true)
        {
            CharacterController.height = crouching;
        }
        else
        {
            CharacterController.height = standing;
        }
    }
}
