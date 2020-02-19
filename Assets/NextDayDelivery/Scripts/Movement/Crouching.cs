using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    [Header("Crouched Values")]
    public float crouching = 0f;
    public float crouchSpeed = 0.1f;

    [Header("Standing Values")]
    public float standing = 0f;
    public float standCam = 0f; 

    [Header("Crouch Checks")]
    public bool crouched = false;
    public bool crouchBlocked = false;

    public LayerMask mask; // Layers to include when raycasting.

    [Space]
    public GameObject Camera;

    void Start()
    {
        crouched = false;
        crouchBlocked = false;
        CharacterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || (crouchBlocked == true))
        {
            crouch();
        }

        else if ((crouchBlocked == false) && (crouched == false))
        {
            unCrouch();
        }

        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouched = false;
        }

        else if (crouchBlocked == false)
        {
            unCrouch();
        }

        crouchBlocked = IsCeilingAbove(1.5f);
    }

    private void crouch()
    {
        crouched = true;
        CharacterController.center = new Vector3(0, 0, 0);
        CharacterController.height = crouching;
    }

    private void unCrouch()
    {
        crouched = false;
        CharacterController.center = new Vector3(0, 0, 0);
        CharacterController.height = standing;
    }

    private bool IsCeilingAbove(float distance)
    {
        Debug.DrawRay(transform.position, transform.up * distance, Color.red);
        return Physics.Raycast(transform.position, transform.up, distance);
    }


}
