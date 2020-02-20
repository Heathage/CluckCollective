using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterDoor : MonoBehaviour
{
    Animator anim;
    public void open()
    {
        anim.SetBool("Open?", true);
    }
}
