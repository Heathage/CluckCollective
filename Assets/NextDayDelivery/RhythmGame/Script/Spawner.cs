using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject note;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(note);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
