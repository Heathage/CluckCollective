using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{
    FMOD.Studio.EventInstance Audiooo;
    private int failLevel = 4;

    private void Start()
    {
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.start();
        Audiooo.setParameterByName("Section", 5);
    }
    void OnTriggerEnter2D(Collider2D note) //If anything collides with the object
    {
        failLevel -= 1;
        Debug.Log(failLevel);
        if (failLevel == 0)
            Audiooo.setParameterByName("Success Level", failLevel);
        {
            Debug.Log("Game Over!");
        }
    }
}