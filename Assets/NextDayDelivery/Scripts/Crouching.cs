using UnityEngine;

public class Crouching : MonoBehaviour
{
    private CharacterController CharacterController;

    public float crouching = 0f;
    public float crouchCam = 0f;

    public float crouchSpeed = 0f;

    public float standing = 0f;
    public float standCam = 0f; 

    public bool crouched = false;

    public KeyCode crouchKey = KeyCode.C;
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            crouched = true;
            CharacterController.center = new Vector3(0, -1, 0);
            CharacterController.height = crouching;
            //GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 0, 0), crouchSpeed);


            //while (CharacterController.height != standing)
            //{
            //    transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            //}
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            crouched = false;
            //GameObject.Find("PRF_MainCamera3D").transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, standCam, 0), crouchSpeed);
            CharacterController.center = new Vector3(0, 0, 0);
            //transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            CharacterController.height = standing;
            //CharacterController.center = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            //CharacterController.center = new Vector3(0, transform.position.y + 0.5f, 0);
        }
    }
}
