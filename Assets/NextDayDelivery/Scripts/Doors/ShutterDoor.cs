using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterDoor : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void open()
    {
        anim.SetBool("Open?", true);
    }
}
