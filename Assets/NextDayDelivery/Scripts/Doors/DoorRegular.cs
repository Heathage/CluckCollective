using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRegular : MonoBehaviour
{
    Animator anim;
    bool Opening;
    public bool Locked;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key) {
            Debug.Log("Unlocked!!!!");
            Locked = false;
        }
        if (Locked == false)
        {
            anim.SetBool("Open?", true);
        } else
        {
            anim.SetTrigger("Locked");
            Debug.Log("locked!!!");
        }
        
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
