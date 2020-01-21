using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypress : MonoBehaviour
{
    public GameObject hit;
    public string keyType;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.right* Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKey(keyType))
        {
            Destroy(gameObject);
        }

    }
}
