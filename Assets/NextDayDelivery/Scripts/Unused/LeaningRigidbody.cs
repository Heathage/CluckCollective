using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaningRigidbody : MonoBehaviour
{
    public float leanDistance = 1f;
    public float leanAngle = 30f;
    public float leanSpeed = 0.1f;

    float leanRightDistance;
    float leanLeftAngle;
    float leanLeftDistance;
    float leanRightAngle;

    [SerializeField]
    private float camHeight = 0.875f;
    public float currentHeight;

    [SerializeField]
    private CrouchingRigidbody crouching;

    private Coroutine moveCoroutine;

    void Start()
    {
        leanRightDistance = leanDistance;
        leanLeftAngle = leanAngle;
        leanLeftDistance = leanDistance * -1;
        leanRightAngle = leanAngle * -1;
        currentHeight = camHeight;
    }

    void Update()
    {
        if (Input.GetKey("e"))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, new Quaternion(0f, 0f, leanRightAngle, 100f), leanSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(leanRightDistance, currentHeight, 0), leanSpeed);
        }

        else if (Input.GetKeyUp("e"))
        {
            transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        else if (Input.GetKey("q"))
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, new Quaternion(0f, 0f, leanLeftAngle, 0f), leanSpeed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(leanLeftDistance, currentHeight, 0), leanSpeed);
        }

        else if (Input.GetKeyUp("q"))
        {
            transform.localPosition = new Vector3(0, currentHeight, 0);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 0, 0), leanSpeed);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            moveCoroutine = null;

        }

        if (!crouching.crouchBlocked && moveCoroutine == null)
        {
            moveCoroutine = StartCoroutine(MoveCamera(new Vector3(0, camHeight, 0), 1.25f));
        }
    }

    private IEnumerator MoveCamera(Vector3 newPosition, float speed)
    {
        Debug.Log("Running");
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * speed;
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, camHeight, 0), t);
            yield return new WaitForFixedUpdate();
        }

        yield return null;
    }
}
