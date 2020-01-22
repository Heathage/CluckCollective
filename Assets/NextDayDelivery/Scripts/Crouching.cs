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

        if (Input.GetKey(crouchKey))
        {
            CharacterController.height = crouching;

            //while (CharacterController.height != standing)
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            //}
        }

        else 
        {
            //CharacterController.center = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            CharacterController.center = new Vector3(0, 1f, 0);
            CharacterController.height = standing;
            //CharacterController.center = new Vector3(0, transform.position.y + 0.5f, 0);
        }
    }
}
