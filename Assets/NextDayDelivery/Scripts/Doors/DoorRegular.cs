using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRegular : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter()
    {
        anim.SetBool("Open?", true);
    }

    void OnTriggerExit()
    {
        //anim.SetBool("Open?", false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
