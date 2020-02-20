using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ShutterDoor door;

    void Interact()
    {
        door.open();
    }
}
