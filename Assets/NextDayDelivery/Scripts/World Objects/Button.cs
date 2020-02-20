using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorRegular door;

    void Interact()
    {
        door.open();
    }
}
